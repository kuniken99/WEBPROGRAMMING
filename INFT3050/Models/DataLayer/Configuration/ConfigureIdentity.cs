using Microsoft.AspNetCore.Identity;

namespace INFT3050.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Employee"));
            await roleManager.CreateAsync(new IdentityRole("Customer"));


            User user = new User
            {
                Name = "Admin Istrator",
                UserName = "Admin001",
                PhoneNumber = "8901 2345"
            };

            var result = await userManager.CreateAsync(user, "123Admin");
            
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }

            User user2 = new User
            {
                Name = "Mark Vincent Delos Santos Sasan Jr.",
                UserName = "MarkMark",
                PhoneNumber = "9012 3456"
            };
            var result2 = await userManager.CreateAsync(user2, "Password1218");
            if (result2.Succeeded)
            {
                await userManager.AddToRoleAsync(user2, "Employee");
            }

            User user3 = new User
            {
                Name = "Jun Ho Choi",
                UserName = "JunHoChoi",
                PhoneNumber = "9234 5678"
            };
            var result3 = await userManager.CreateAsync(user3, "Password1234");
            if (result3.Succeeded)
            {
                await userManager.AddToRoleAsync(user3, "Employee");
            }

            User user4 = new User
            {
                Name = "Kennedy Tan",
                UserName = "KennedyTan",
                PhoneNumber = "8123 4567"
            };
            var result4 = await userManager.CreateAsync(user4, "Password1234");
            if (result4.Succeeded)
            {
                await userManager.AddToRoleAsync(user4, "Employee");
            }

            User user5 = new User
            {
                Name = "Suhain Deegala",
                UserName = "SuhainDeegala",
                PhoneNumber = "9123 4567"
            };
            var result5 = await userManager.CreateAsync(user5, "Password1234");
            if (result5.Succeeded)
            {
                await userManager.AddToRoleAsync(user5, "Employee");
            }

            User user6 = new User
            {
                Name = "Cus Tomer",
                UserName = "Customer01",
                Email = "Customer123@gmail.com",
                Address = "342 Choa Chu Kang Crescent, 680342 Singapore",
                PhoneNumber = "12345678",

            };
            var result6 = await userManager.CreateAsync(user6, "Customer123");
            if (result6.Succeeded)
            {
                await userManager.AddToRoleAsync(user6, "Customer");
            }


            
        }
    }

}
