using EventTracker.Data;
using EventTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public class CategoryService : ICategoryService<Category>
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ChangeActiveStatus(Category entity)
        {
            var category = this.GetById(entity.Id);

            category.IsActive = !category.IsActive;
            category.EditedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Create(Category entity)
        {
            await this.dbContext.Categories.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAll(bool? withNonActive = false, int? count = null)
        {
            return this.dbContext.Categories.Where(c => (withNonActive == true ? true : c.IsActive == true));
        }

        public Category GetById(int id, bool? withNonActive = false)
        {
            return this.dbContext.Categories.Where(c => c.Id == id && (withNonActive == true ? true : c.IsActive == true)).FirstOrDefault();
        }

        public async Task Update(Category entity)
        {
            var category = this.GetById(entity.Id);

            if (category == null)
            {
                return;
            }

            category.Name = entity.Name;
            category.NormalizedName = entity.Name.ToUpper();
            category.EditedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
