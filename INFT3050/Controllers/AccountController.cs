using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using INFT3050.Models;
using INFT3050.Areas.Admin.Models;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;

namespace INFT3050.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;
        private VitaStoreContext context;

        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr,
            RoleManager<IdentityRole> roleMngr, VitaStoreContext ctx)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            roleManager = roleMngr;
            context = ctx;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            //return the SignUp Page
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CustomerRegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                //create a new User object based on the provided model data
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.Username,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };

                //attempt to create a new user in the system
                var result = await userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    //if result succeeded attempt to assign a role to the user
                    var roleResult = await userManager.AddToRoleAsync(user, "Customer");
                    if (roleResult.Succeeded)
                    {
                        //sign in the user and redirect to the Index Page
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home"); //first parameter - method, second parameter - controller
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
            //if model state is not valid or user creation failed, return to the view
            return View(model);
        }

        [HttpGet]
        //accept an optional string parameter with a default value of an empty string.
        public IActionResult LogIn(string returnURL = "") 
        {
            // create an instance of LoginViewModel and set its ReturnUrl property to the value of returnURL.
            var model = new LoginViewModel { ReturnUrl = returnURL }; 
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to find the user by the username provided in the login model
                var user = await userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    // Check if the user account is locked out
                    if (await userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Your account is locked out. Please try again later.");
                        return View(model);
                    }

                    // Attempt to sign in the user with the provided username and password
                    var result = await signInManager.PasswordSignInAsync(
                        model.Username, model.Password, isPersistent: model.RememberMe,
                        lockoutOnFailure: true);

                    if (result.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);

                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }

                        // Redirect based on the user's role
                        foreach (var role in roles)
                        {
                            if (role == "Admin")
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else if (role == "Employee")
                            {
                                return RedirectToAction("Index", "Employee");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }

                    // If the login failed, check the result status and add appropriate errors
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Your account is locked out. Please try again later.");
                        return View(model);
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("", "You are not allowed to login.");
                        return View(model);
                    }
                    else
                    {
                        var accessFailedCount = await userManager.GetAccessFailedCountAsync(user);
                        var maxAttempts = userManager.Options.Lockout.MaxFailedAccessAttempts;
                        var attemptsLeft = maxAttempts - accessFailedCount;

                        ModelState.AddModelError("", $"Invalid username/password. {attemptsLeft} attempt(s) left before account is locked out.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username/password.");
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            //get the current cart and end the session when the user logs out
            var cart = new Cart(HttpContext);
            cart.EndSession();
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        public IActionResult UpdatePassword()
        {
            return View();

        }

        [HttpGet]
        public IActionResult ChangeEmail()
        {
            var model = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePhoneNumber()
        {
            var model = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(model);
        }



        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Find the user by their username
                User user = await userManager.FindByNameAsync(model.Username);

                // Attempt to change the user's password
                var result = await userManager.ChangePasswordAsync(user,
                    model.OldPassword, model.NewPassword);
                
                // Retrieve the roles associated with the user
                var roles = await userManager.GetRolesAsync(user);

                if (result.Succeeded)
                {
                    TempData["message"] = "Password changed successfully";

                    // Redirect the user based on their role
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    }
                    else if(roles.Contains("Employee"))
                    {
                        return RedirectToAction("Index", "Employee", new { area = "Employee" });
                    }
                    else
                    { 
                    return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

       


        [Authorize]
        public async Task<IActionResult> AccountDetails(string name)
        {
            // Find the user based on the provided username
            User user = await userManager.FindByNameAsync(name);

            // Retrieve the roles associated with the user
            var roles = await userManager.GetRolesAsync(user);


            if (roles.Contains("Admin") || roles.Contains("Employee"))
            {
                return View("~/Views/Account/StaffAccountDetails.cshtml", user);
            }
            else
            {
                CustomerProfileViewModel model = new CustomerProfileViewModel
                {
                    Username = user.UserName,
                    FullName = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address
                };

                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomerProfile(CustomerProfileViewModel model)
        {

            User user = await userManager.FindByNameAsync(model.Username);
            
            if (ModelState.IsValid)
            {
                user.UserName = model.Username;
                user.Name = model.FullName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;

                var result = await userManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home"); //first parameter - method, second parameter - controller

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
                        //logging mechanism here
                        Console.WriteLine($"ModelState Error: {subError.ErrorMessage}");
                    }
                }
            }
            return View("~/Views/Account/AccountDetails.cshtml", model);

        }

        public async Task<IActionResult> OrderHistory(string name)
        {
            User user = await userManager.FindByNameAsync(name);
            OrderHistoryViewModel model = new OrderHistoryViewModel
            {
                CustomerUserHistory = user,
                Orders = context.Orders.ToList()
            };
            ViewBag.Action = "EditCustomer";
            return View(model);
        }

        public async Task<IActionResult> OrderHistoryDetail(int id)
        {
            var order = context.Orders.Find(id);

            OrderHistoryDetailViewModel model = new OrderHistoryDetailViewModel
            {
                OrderHistory = order,
                OrderItems = context.OrderItems.ToList(),
                OrderImages = context.Images.ToList(),
                Items = context.Items.ToList()
            };

            return View(model);
        }
    }
}
