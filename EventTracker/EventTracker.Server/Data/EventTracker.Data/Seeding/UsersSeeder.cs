using EventTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Data.Seeding
{
    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync("admin");

            if (user == null)
            {
                var result = await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@abv.bg",
                    EmailConfirmed = true,
                }, "admin1234");

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
