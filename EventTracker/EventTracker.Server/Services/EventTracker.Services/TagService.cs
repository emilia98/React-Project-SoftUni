using EventTracker.Data;
using EventTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public class TagService : ICommonService<Tag>
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task ChangeActiveStatus(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Task Create(Tag entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll(bool? withNonActive = false, int? count = null)
        {
            // TODO: Implement this returning specified count of elements
            return this.dbContext.Tags.Where(t => t.IsActive == !withNonActive);
        }

        public Tag GetById(int id, bool? withNonActive = false)
        {
            return this.dbContext.Tags.Where(t => t.Id == id && t.IsActive == !withNonActive).FirstOrDefault();
        }

        public Task Update(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
