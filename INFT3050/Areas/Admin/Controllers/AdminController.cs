using INFT3050.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace INFT3050.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    //[Route ("Admin/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly VitaStoreContext _context;

        public AdminController(VitaStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult ViewOrder()
        {
            return View();
        }

        public IActionResult ViewProduct()
        {
            return View();

        }

    }
}
