using JWTExample.Contexts;
using JWTExample.Models;
using Microsoft.AspNetCore.Identity;

namespace JWTExample.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static async Task SeedIdentityDataAsync(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                await ApplicationDbContextSeed.SeedEssentialsAsync(userManager, roleManager);
            }
        }
    }
}
