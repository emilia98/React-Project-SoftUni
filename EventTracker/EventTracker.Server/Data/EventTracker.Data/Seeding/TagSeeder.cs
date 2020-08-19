using EventTracker.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Data.Seeding
{
    public class TagSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            await SeedTagsAsync(dbContext);
        }

        private static async Task SeedTagsAsync(ApplicationDbContext dbContext)
        {
            var tagsCount = dbContext.Tags.Count();

            if (tagsCount > 0)
            {
                return;
            }

            var tag = new Tag
            {
                Name = "Music",
                NormalizedName = "Music".ToUpper(),
                CreatedOn = DateTime.UtcNow,
                EditedOn = DateTime.UtcNow,
                IsActive = true
            };

            await dbContext.Tags.AddAsync(tag);
        }
    }
}
