using INFT3050.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace INFT3050.Areas.Employee.Controllers
{
    [Authorize(Roles = "Employee")]
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private VitaStoreContext context { get; set; }

        public EmployeeController(UserManager<User> userMngr, VitaStoreContext ctx, RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            context = ctx;
            roleManager = roleMngr;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewProducts()
        {
            var vm = new ItemImageListViewModel
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };
            return View(vm);
        }

        public IActionResult ManageItem()
        {
            return View();
        }

        public async Task<IActionResult> ViewUsers()
        {
            List<User> users = new List<User>();
            foreach (User user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
            };
            return View(model);
        }
        

    }
}
