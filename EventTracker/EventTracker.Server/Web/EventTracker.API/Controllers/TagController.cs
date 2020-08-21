using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Models;
using EventTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventTracker.API.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> logger;
        private readonly ITagService<Tag> tagService;

        public TagController(ILogger<TagController> logger, ITagService<Tag> tagService)
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
        public async Task<IActionResult> Create(Tag tagData)
        {
            Console.WriteLine("Name = " + tagData.Name);

            /*
            var tag = new Tag
            {
                Name = name,
                NormalizedName = name.ToUpper(),
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
                // return this.Problem("")
            }*/

            return this.Ok("Tag created successfully!");
        }
    }
}

