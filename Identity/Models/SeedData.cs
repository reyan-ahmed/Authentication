using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class SeedData
    {
        public static async Task SeedDataAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = "super@admin.com",
                    UserName = "super@admin.com"
                };

                await userManager.CreateAsync(user, "P@ssw0rd");
                var role = await roleManager.FindByNameAsync("Admin");
                var currentUser = await userManager.FindByNameAsync(user.UserName);
                await userManager.AddToRoleAsync(currentUser, role.Name);
            }
        }
    }
}
