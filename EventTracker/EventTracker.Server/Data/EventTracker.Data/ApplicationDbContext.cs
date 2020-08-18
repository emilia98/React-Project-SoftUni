using Microsoft.EntityFrameworkCore;

namespace EventTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
    }
}
