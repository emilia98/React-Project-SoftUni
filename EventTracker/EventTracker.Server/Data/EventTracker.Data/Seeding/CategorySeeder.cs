using EventTracker.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Data.Seeding
{
    public class CategorySeeder : ISeeder
    {
        private static string categoryName = "Music Concerts";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider = null)
        {
            await SeedCategoriesAsync(dbContext);
        }

        private static async Task SeedCategoriesAsync(ApplicationDbContext dbContext)
        {
            var categoriesCount = dbContext.Categories.Count();

            if (categoriesCount > 0)
            {
                return;
            }

            var category = new Category
            {
                Name = categoryName,
                NormalizedName = categoryName.ToUpper(),
                CreatedOn = DateTime.UtcNow,
                EditedOn = DateTime.UtcNow,
                IsActive = true
            };

            await dbContext.Categories.AddAsync(category);
        }
    }
}
