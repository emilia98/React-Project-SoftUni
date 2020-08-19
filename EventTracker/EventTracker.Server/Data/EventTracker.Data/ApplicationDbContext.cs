using EventTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
