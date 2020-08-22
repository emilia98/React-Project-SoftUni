using EventTracker.Data;
using EventTracker.InputModels;
using EventTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public class CategoryService : ICategoryService<Category, CategoryInputModel>
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ChangeActiveStatus(Category entity)
        {
            // var category = this.GetById(entity.Id);

            entity.IsActive = !entity.IsActive;
            entity.EditedOn = DateTime.UtcNow;

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

        public async Task Update(Category entity, CategoryInputModel categoryInput)
        {
            //var category = this.GetById(entity.Id);

            //if (category == null)
            //{
            //    return false;
            //}

            entity.Name = categoryInput.Name;
            entity.NormalizedName = categoryInput.Name.ToUpper();
            entity.EditedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
