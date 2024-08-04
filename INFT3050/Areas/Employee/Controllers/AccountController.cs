using INFT3050.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace INFT3050.Areas.Employee.Controllers
{
    [Authorize(Roles = "Employee")]
    [Area("Employee")]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;

        public AccountController(UserManager<User> userMngr)
        {
            userManager = userMngr;
        }
        public async Task<IActionResult> EmployeeAccountDetails(string name)
        {
            User user = await userManager.FindByNameAsync(name);

            return View(user);

        }
    }
}
