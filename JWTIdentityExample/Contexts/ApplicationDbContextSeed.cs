using JWTIdentityExample.Constants;
using JWTIdentityExample.Models;
using Microsoft.AspNetCore.Identity;

namespace JWTIdentityExample.Contexts
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            await roleManager.CreateAsync(new ApplicationRole(Authorization.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(Authorization.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(Authorization.Roles.User.ToString()));

            //var defaultUser = new ApplicationUser
            //{
            //    UserName = Authorization.DEFAULT_USERNAME,
            //    Email = Authorization.DEFAULT_EMAIL,
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (userManager.Users.All(u => u.Id != defaultUser.Id))
            //{
            //    await userManager.CreateAsync(defaultUser, Authorization.DEFAULT_PASSWORD);
            //    await userManager.AddToRoleAsync(defaultUser, Authorization.DEFAULT_ROLE.ToString());
            //}
        }
    }
}
