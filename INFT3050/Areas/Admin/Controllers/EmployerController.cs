using Microsoft.AspNetCore.Mvc;

namespace INFT3050.Areas.Admin.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
