namespace INFT3050.Models
{
    public class Cart
    {

        private const string CartKey = "mycart";
        private const string CountKey = "mycount";

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        
        private List<CartItem> items { get; set; } = null!;
        private List<CartItemDTO> cookieItems { get; set; } = null!;

        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
        }

        public void Load(VitaStoreContext context)
        {
            // get cart items from session and cookie
            items = session.GetObject<List<CartItem>>(CartKey)
                ?? new List<CartItem>();
            cookieItems = requestCookies.GetObject<List<CartItemDTO>>(CartKey)
                ?? new List<CartItemDTO>();

            // if more items in cookie than session, restore from database
            if (cookieItems.Count > items.Count)
            {
                items.Clear(); // clear any previous session data

                foreach (CartItemDTO storedItem in cookieItems)
                {
                    var item = context.Items.Find(storedItem.ItemID);

                    // skip if book is null - it's no longer in database
                    if (item != null)
                    {
                        CartItem cItem = new CartItem
                        {
                            Item = new ItemDTO(item),
                            Quantity = storedItem.Quantity
                        };
                        items.Add(cItem);
                    }
                }
                Save();
            }
        }
        public double Subtotal => items.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);
        public IEnumerable<CartItem> List => items;

        public CartItem? GetById(int? id)
        {
            if (items == null || id == null)
            {
                return null;
            }
            else
            {
                return items.FirstOrDefault(ci => ci.Item?.ItemID == id);
            }
        }

        public void Add(CartItem item)
        {
            var itemInCart = GetById(item.Item.ItemID);
            // if new, add
            if (itemInCart == null)
            {
                items.Add(item);
            }
            else
            {  // otherwise, increase quantity amount by 1
                itemInCart.Quantity += 1;
            }
        }

        public void Edit(CartItem item)
        {
            var itemInCart = GetById(item.Item.ItemID);
            if (itemInCart != null)
            {
                itemInCart.Quantity = item.Quantity;
            }
        }

        public void Remove(CartItem item) => items.Remove(item);
        public void Clear() => items.Clear();

        public void Save()
        {
            if (items.Count == 0)
            {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else
            {
                session.SetObject<List<CartItem>>(CartKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject<List<CartItemDTO>>(CartKey, items.ToDTO());
                responseCookies.SetInt32(CountKey, items.Count);
            }
        }

        public void EndSession()
        {
            session.Remove(CartKey);
            session.Remove(CountKey);
            responseCookies.Delete(CartKey);
            responseCookies.Delete(CountKey);
        }
    }
}
