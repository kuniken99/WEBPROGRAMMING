using INFT3050.Areas.Admin.Models;
using INFT3050.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace INFT3050.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area ("Admin")]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr, RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            roleManager = roleMngr;
        }

        public async Task<IActionResult> ManageUsers()
        {
            List<User> users = new List<User>();
            //add user objects to the list users
            foreach (User user in userManager.Users)
            {
                //get the role of the user
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }

            //initialize view model for the view
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddEmployee(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Create a new User object with properties from the view model
                var user = new User 
                {
                    Name = model.Name,
                    UserName = model.Username,
                    PhoneNumber = model.PhoneNumber
                    
                };
                var result = await userManager.CreateAsync(user, model.Password);
                
                
                if (result.Succeeded)
                {
                    //set the role of the user and return to the page Manage Users
                    var roleResult = await userManager.AddToRoleAsync(user, model.Role);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("ManageUsers", "Account"); //first parameter - method, second parameter - controller
                    }
                }
                else
                {
                    // If role assignment fails, add role-related errors to the model state
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            // If the model state is invalid or if there were errors, return the view with the current model
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(string id)
        {

            User user = await userManager.FindByIdAsync(id);
            EditEmployeeViewModel model = new EditEmployeeViewModel
            {
                Name = user.Name,
                Role = (await userManager.GetRolesAsync(user))[0],
                Username = user.UserName,
                PhoneNumber = user.PhoneNumber,
                EmployeeID = id
            };

            ViewBag.Action = "EditEmployee";
            return View("~/Areas/Admin/Views/Account/EditEmployee.cshtml", model);

        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeViewModel model)
        {

            // Find the user based on the provided EmployeeID
            User user = await userManager.FindByIdAsync(model.EmployeeID);
            if (ModelState.IsValid)
            {
                // Update the user properties with the values from the view model
                user.Name = model.Name;
                user.UserName = model.Username;
                user.PhoneNumber = model.PhoneNumber;

                // Attempt to update the user in the database
                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Retrieve the current roles assigned to the user
                    var currentRoles = await userManager.GetRolesAsync(user);

                    // Attempt to remove the user from all existing roles
                    var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);

                    if (!removeResult.Succeeded)
                    {
                        // If role removal fails, add errors to the model state and return to the view
                        foreach (var error in removeResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        ViewBag.Action = "EditEmployee";
                        return View("EditEmployee", model);
                    }

                    // Attempt to assign the new role to the user and go to Manage Users View
                    var roleResult = await userManager.AddToRoleAsync(user, model.Role);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("ManageUsers", "Account");
                    }
                    else
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            // Find the user by their ID
            User user = await userManager.FindByIdAsync(id);

            // Check if the user exists
            if (user != null)
            {
                // Attempt to delete the user from the system
                IdentityResult result = await userManager.DeleteAsync(user);

                if (!result.Succeeded) 
                {
                    // If deletion failed, concatenate all error descriptions into a single message
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    // Store the error message in TempData to display it on the next request
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("ManageUsers", "Account"); //first parameter - method, second parameter - controller
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomer(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            EditCustomerViewModel model = new EditCustomerViewModel
            {
                Name = user.Name,
                Username = user.UserName,
                PhoneNumber = user.PhoneNumber,
                CustomerID = id
            };
            ViewBag.Action = "EditCustomer";
            return View("~/Areas/Admin/Views/Account/EditCustomer.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(EditCustomerViewModel model)
        {
            // Retrieve the user based on the provided CustomerID
            User user = await userManager.FindByIdAsync(model.CustomerID);
            if (ModelState.IsValid)
            {
                // Update the user's properties with the values from the view model
                user.Name = model.Name;
                user.UserName = model.Username;
                user.PhoneNumber = model.PhoneNumber;

                // Attempt to update the user in the database
                var result = await userManager.UpdateAsync(user);

                // Check if the user update was successful and redirect to Manage Users Page
                if (result.Succeeded)
                {
                    return RedirectToAction("ManageUsers", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
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

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            //retrieve the user using the ID
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                //attempt to delete the user from the database and return to Manage Users Page
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("ManageUsers", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> AdminChangePassword(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            AdminChangePasswordViewModel model = new AdminChangePasswordViewModel
            {
                Username = user.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminChangePassword(AdminChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user based on the provided username
                User user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    // Generate a password reset token for the user
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    // Attempt to reset the user's password using the generated token and the new password
                    var result = await userManager.ResetPasswordAsync(user, token, model.NewPassword);

                    // Check if the password reset operation was successful then redirect to the ManageUsers Page
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ManageUsers", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> AdminAccountDetails(string name)
        {
            User user = await userManager.FindByNameAsync(name);

               return View(user);
           
        }

    }
}
