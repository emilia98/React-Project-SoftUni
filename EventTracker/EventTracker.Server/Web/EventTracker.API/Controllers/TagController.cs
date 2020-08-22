﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.InputModels;
using EventTracker.Models;
using EventTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventTracker.API.Controllers
{
    [Route("admin/[controller]")]
   // [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> logger;
        private readonly ITagService<Tag, TagInputModel> tagService;

        public TagController(ILogger<TagController> logger, ITagService<Tag, TagInputModel> tagService)
        {
            this.logger = logger;
            this.tagService = tagService;
        }

        [HttpGet]
        public IEnumerable<Tag> GetAll()
        {
            return this.tagService.GetAll(true).ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            bool isIdCorrect = int.TryParse(id, out int tagId);

            if(!isIdCorrect)
            {
                return this.NotFound("Tag does not exist!");
            }

            var tag = this.tagService.GetById(tagId, true);

            if (tag == null)
            {
                return this.NotFound("Tag does not exist!");
            }

            return this.Ok(tag);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] TagInputModel tagData)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.ToDictionary(x => x.Key, x => x.Value.Errors));
            }
            
            var tag = new Tag
            {
                Name = tagData.Name,
                NormalizedName = tagData.Name.ToUpper(),
                CreatedOn = DateTime.UtcNow,
                EditedOn = DateTime.UtcNow,
                IsActive = true
            };

            try
            {
                await this.tagService.Create(tag);
            }
            catch(Exception e)
            {
                this.logger.LogError(e.Message);
                this.logger.LogInformation(e.StackTrace);
                return this.BadRequest("An error occurred while trying to create a tag!");
            }

            return this.Ok("Tag created successfully!");
        }

        [HttpPost("status/change/{id}")]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            bool isIdCorrect = int.TryParse(id, out int tagId);

            if (!isIdCorrect)
            {
                return this.NotFound("Tag does not exist!");
            }

            var tag = this.tagService.GetById(tagId, true);

            if (tag == null)
            {
                return this.NotFound("Tag does not exist!");
            }

            try
            {
                await this.tagService.ChangeActiveStatus(tag);
            }
            catch(Exception e)
            {
                this.logger.LogError(e.Message);
                this.logger.LogInformation(e.StackTrace);
                return this.BadRequest("An error occurred while trying to change the status of the tag!");
            }

            return this.Ok(new
            {
                Message = "Successfully changed the status of the tag!",
                Tag = tag
            });
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditGet(string id)
        {
            bool isIdCorrect = int.TryParse(id, out int tagId);

            if (!isIdCorrect)
            {
                return this.NotFound("Tag does not exist!");
            }

            var tag = this.tagService.GetById(tagId, true);

            if (tag == null)
            {
                return this.NotFound("Tag does not exist!");
            }

            return this.Ok(tag);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditPost(string id, [FromBody] TagInputModel tagInput)
        {
            bool isIdCorrect = int.TryParse(id, out int tagId);

            if (!isIdCorrect)
            {
                return this.NotFound("Tag does not exist!");
            }

            var tag = this.tagService.GetById(tagId, true);

            if (tag == null)
            {
                return this.NotFound("Tag does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.ToDictionary(x => x.Key, x => x.Value.Errors));
            }

            try
            {
                await this.tagService.Update(tag, tagInput);
            }
            catch(Exception e)
            {
                this.logger.LogError(e.Message);
                this.logger.LogInformation(e.StackTrace);
                return this.BadRequest("An error occurred while trying to edit tag!");
            }

            return this.Ok("Successfully edited tag!");
        }
    }
}

