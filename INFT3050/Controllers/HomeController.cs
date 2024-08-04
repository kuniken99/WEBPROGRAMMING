using INFT3050.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace INFT3050.Controllers
{
    public class HomeController : Controller
    {
        private VitaStoreContext context { get; set; }

        public HomeController(VitaStoreContext staffctx) => context = staffctx;

        //private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            var vm = new ItemImageListViewModel()
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };
            return View(vm);
        }

        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }


        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Category()
        {
            var vm = new ItemImageListViewModel()
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };
            return View(vm);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        { 
            return View(); 
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AccountDetails()
        {
            return View();
        }


       
        /*public IActionResult ManageStaff()
        {
            var staff = context.StaffMembers.ToList();
            return View(staff);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }







    }
}
