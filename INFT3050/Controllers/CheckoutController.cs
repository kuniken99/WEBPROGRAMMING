using Microsoft.AspNetCore.Mvc;

namespace INFT3050.Controllers
{
    public class CheckoutController : Controller
    {

        public IActionResult CartPage()
        {
            return View();
        }

        public IActionResult CheckOutPage()
        {
            return View();
        }

        public IActionResult PaymentPage()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult PaymentConfirmation()
        {
            return View();
        }
    }
}
