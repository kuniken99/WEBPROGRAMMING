namespace INFT3050.Models
{
    public class CartViewModel
    {
        public User CustomerUser { get; set; }
        public List<Image> Images { get; set; }
        public Item Product { get; set; }
        public IEnumerable<CartItem> List { get; set; } = new List<CartItem>();
        //public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }
}
