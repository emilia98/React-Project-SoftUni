using EventTracker.Data;
using EventTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public class TagService : ITagService<Tag>
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ChangeActiveStatus(Tag entity)
        {
            var tag = this.GetById(entity.Id);

            tag.IsActive = !tag.IsActive;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Create(Tag entity)
        {
            await this.dbContext.Tags.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<Tag> GetAll(bool? withNonActive = false, int? count = null)
        {
            // TODO: Implement this returning specified count of elements
            return this.dbContext.Tags.Where(t => t.IsActive == !withNonActive.Value);
        }

        public Tag GetById(int id, bool? withNonActive = false)
        {
            return this.dbContext.Tags.Where(t => t.Id == id && (withNonActive == true ? true : t.IsActive == true)).FirstOrDefault();
        }

        public async Task Update(Tag entity)
        {
            var tag = this.GetById(entity.Id);

            tag.Name = entity.Name;
            tag.NormalizedName = entity.Name.ToUpper();
            tag.EditedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
