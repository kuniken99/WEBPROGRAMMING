using Microsoft.AspNetCore.Mvc;
using INFT3050.Models; // Ensure this namespace is correct
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using INFT3050.Areas.Admin.Models;

namespace INFT3050.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly VitaStoreContext _context;

        public OrderController(VitaStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ManageOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Customer) // Ensure Customer is included
                .ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> UpdateOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Customer) // Ensure Customer is included
                .FirstOrDefaultAsync(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageOrders));
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult UpdateOrderStatus(int id)
        {
            
            ViewBag.Action = "UpdateStatus";
            var order = _context.Orders.Find(id);
            var model = new OrderStatusViewModel
            {
                OrderID = id,
                OrderDate = order.Date,
                OrderStatus = order.Status

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(OrderStatusViewModel model)
        {
            var order = _context.Orders.Find(model.OrderID);
            //check if the data type the user entered is valid
            if (ModelState.IsValid)
            {
                order.Status = model.OrderStatus;
                _context.SaveChanges();
                return RedirectToAction("ManageOrders", "Order"); //first parameter - method, second parameter - controller
            }
            //if user input an invalid data type
            else
            {
                foreach (var error in ModelState)
                {
                    foreach (var subError in error.Value.Errors)
                    {
                        // Use your preferred logging mechanism here (e.g., Console, Serilog, etc.)
                        Console.WriteLine($"ModelState Error: {subError.ErrorMessage}");
                    }
                }

                return View(model);
            }
        }
    }
}
