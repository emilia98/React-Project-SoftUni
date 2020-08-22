﻿using EventTracker.Data;
using EventTracker.InputModels;
using EventTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public class TagService : ITagService<Tag, TagInputModel>
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ChangeActiveStatus(Tag entity)
        {
            // var tag = this.GetById(entity.Id);

            entity.IsActive = !entity.IsActive;
            entity.EditedOn = DateTime.UtcNow;

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
            return this.dbContext.Tags.Where(t => (withNonActive == true ? true : t.IsActive == true));
        }

        public Tag GetById(int id, bool? withNonActive = false)
        {
            return this.dbContext.Tags.Where(t => t.Id == id && (withNonActive == true ? true : t.IsActive == true)).FirstOrDefault();
        }

        public async Task Update(Tag entity, TagInputModel tagInput)
        {
            //var tag = this.GetById(entity.Id);

            //if (tag == null)
            //{
            //    return false;
            //}

            entity.Name = tagInput.Name;
            entity.NormalizedName = tagInput.Name.ToUpper();
            entity.EditedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
