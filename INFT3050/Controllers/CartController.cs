using INFT3050.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace INFT3050.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private VitaStoreContext context { get; set; }
        private UserManager<User> userManager;

        public CartController(VitaStoreContext ctx, UserManager<User> userMngr)
        {
            userManager = userMngr;
            context = ctx;
        }

        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(context);
            return cart;
        }

        public async Task<ViewResult> CartPage()
        {
            //get the id of the user   
            var userId = userManager.GetUserId(User);
            //create a user variable for the viewmodel
            User user = await userManager.FindByIdAsync(userId);
            //get the cart in the session
            Cart cart = GetCart();
            var vm = new CartViewModel
            {
                //set view model properties and send it to the view file
                CustomerUser = user,
                List = cart.List,
                Images = context.Images.ToList(),
                Subtotal = cart.Subtotal
            };
            return View(vm);
        }

        public async Task<IActionResult> CheckOutPage(string id)
        {
            // Retrieve the user from the database using the provided user ID
            User user = await userManager.FindByIdAsync(id);

            // Get the current cart from the session
            Cart cart = GetCart();
            if (cart.List.Count() > 0) 
            { 
            var vm = new CartViewModel
            {
                // if the cart has any item create a view model for the checkout page
                CustomerUser = user,
                List = cart.List,
                Images = context.Images.ToList(),
                Subtotal = cart.Subtotal
            };
                // Return the view with the populated view model
            return View(vm);
            }
            else
            {
                return RedirectToAction("CartPage");
            }
        }

        public async Task<IActionResult> Payment(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            Cart cart = GetCart();
            var vm = new CartViewModel
            {
                List = cart.List,
                Images = context.Images.ToList(),
                Subtotal = cart.Subtotal
            };
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> PayNow()
        {
            // Retrieve the current cart from the session or context
            Cart cart = GetCart();

            // Get the ID of the currently logged-in user
            var userId = userManager.GetUserId(User);
            // Fetch the user details from the database using the retrieved ID
            User user = await userManager.FindByIdAsync(userId);

            if (ModelState.IsValid)
            {
                // Create a new order object
                var order = new Order
                {
                    UserID = user.Id,
                    Date = DateTime.Now,
                    Status = 1,
                    OrderHistorySubtotal = cart.Subtotal
                };

                context.Orders.Add(order);
                // add the new order to the database and save the changes
                await context.SaveChangesAsync();

                // Iterate through each item in the cart
                foreach (var item in cart.List) 
                {
                    // Create an orderitem for each cart item
                    var orderitem = new OrderItem
                    {
                        ItemID = item.Item.ItemID,
                        OrderID = order.OrderID,
                        Quantity = item.Quantity,
                        OrderItemStubtotal = item.Subtotal
                    };

                    // Find the item in inventory
                    var invItem = context.Items.Find(item.Item.ItemID);

                    // Update the inventory quantity based on the quantity ordered
                    invItem.Quantity -= item.Quantity;

                    // Add the order item to the database context
                    context.OrderItems.Add(orderitem);
                    
                }

                // Save the changes to the database
                await context.SaveChangesAsync();
                // End the user's session and clear the cart
                cart.EndSession();
                return View("PaymentConfirmation");

            }

            else
            {
                // Log ModelState errors
                foreach (var error in ModelState)
                {
                    foreach (var subError in error.Value.Errors)
                    {
                        //logging mechanism
                        Console.WriteLine($"ModelState Error: {subError.ErrorMessage}");
                    }
                }
            }

            return View ("CartPage");
           

        }

        [HttpPost]
        public RedirectToActionResult Add(int id, int quantity = 1)
        {
            // Find the item in the database using the provided ID
            var item = context.Items.Find(id);

            if (item != null)
            {
                // Retrieve the current cart from the session or context
                Cart cart = GetCart();

                // Check if the item already exists in the cart
                var cartItem = cart.List.FirstOrDefault(i => i.Item.ItemID == id);

                if (cartItem != null)
                {
                    // Update the quantity if the item already exists in the cart
                    cartItem.Quantity += quantity;
                }
                else
                {
                    //ensure that the item will not exceed the stock of the item
                    if (item.Quantity >= quantity)
                    {
                        // Add new item to the cart
                        CartItem cItem = new CartItem
                        {
                            Item = new ItemDTO(item),
                            Quantity = quantity
                        };
                        cart.Add(cItem);
                    }
                    else
                    {
                        TempData["message"] = $"{item.ItemName} doesn't have enough stock";
                    }
                }

                cart.Save();
                TempData["message"] = $"{item.ItemName} added to cart";
            }
            
            return RedirectToAction("CartPage");
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem? cItem = cart.GetById(id);
            if (cItem != null)
            {
                // Remove the item from the cart
                cart.Remove(cItem);
                // Save the updated cart state
                cart.Save();
                TempData["message"] = $"{cItem.Item.ItemName} removed from cart.";
            }
            return RedirectToAction("CartPage");
        }

        [HttpPost]
        public RedirectToActionResult UpdateQuantity(int id, int quantity)
        {
            Cart cart = GetCart();
            CartItem? cItem = cart.GetById(id);
            if (cItem != null && quantity > 0)
            {
                // Update the quantity of the item in the cart
                cItem.Quantity = quantity;
                // Save the updated cart state
                cart.Save();
                TempData["message"] = $"{cItem.Item.ItemName} quantity updated.";
            }
            return RedirectToAction("CartPage");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();
            TempData["message"] = "Cart cleared.";
            return RedirectToAction("CartPage");
        }

    }
}
