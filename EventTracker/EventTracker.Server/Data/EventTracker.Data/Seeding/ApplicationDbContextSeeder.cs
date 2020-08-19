using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTracker.Data.Seeding
{
    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            var seeders = new List<ISeeder>
            {
                new TagSeeder(),
                new CategorySeeder()
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
