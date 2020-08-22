using System;
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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryService<Category, CategoryInputModel> categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService<Category, CategoryInputModel> categoryService)
        {
            this.logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return this.categoryService.GetAll(true).ToArray();
        }

        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            bool isIdCorrect = int.TryParse(id, out int categoryId);

            if (!isIdCorrect)
            {
                return this.NotFound("Category does not exist!");
            }

            var category = this.categoryService.GetById(categoryId, true);

            if (category == null)
            {
                return this.NotFound("Category does not exist!");
            }

            return this.Ok(category);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CategoryInputModel categoryData)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.ToDictionary(x => x.Key, x => x.Value.Errors));
            }

            var category = new Category
            {
                Name = categoryData.Name,
                NormalizedName = categoryData.Name.ToUpper(),
                CreatedOn = DateTime.UtcNow,
                EditedOn = DateTime.UtcNow,
                IsActive = true
            };

            try
            {
                await this.categoryService.Create(category);
            }
            catch(Exception e)
            {
                this.logger.LogError(e.Message);
                this.logger.LogInformation(e.StackTrace);
                return this.BadRequest("An error occurred while trying to create a category!");
            }

            return this.Ok("Category created successfully!");
        }

        [HttpPost("status/change/{id}")]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            bool isIdCorrect = int.TryParse(id, out int categoryId);

            if (!isIdCorrect)
            {
                return this.NotFound("Category does not exist!");
            }

            var category = this.categoryService.GetById(categoryId, true);

            if (category == null)
            {
                return this.NotFound("Category does not exist!");
            }

            try
            {
                await this.categoryService.ChangeActiveStatus(category);
            }
            catch(Exception e)
            {
                this.logger.LogError(e.Message);
                this.logger.LogInformation(e.StackTrace);
                return this.BadRequest("An error occurred while trying to change the status of the category!");
            }

            return this.Ok(new
            {
                Message = "Successfully changed the status of the category!",
                Category = category
            });
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditGet(string id)
        {
            bool isIdCorrect = int.TryParse(id, out int categoryId);

            if (!isIdCorrect)
            {
                return this.NotFound("Category does not exist!");
            }

            var category = this.categoryService.GetById(categoryId, true);

            if (category == null)
            {
                return this.NotFound("Category does not exist!");
            }

            return this.Ok(category);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditPost(string id, [FromBody] CategoryInputModel categoryInput)
        {
            bool isIdCorrect = int.TryParse(id, out int categoryId);

            if (!isIdCorrect)
            {
                return this.NotFound("Category does not exist!");
            }

            var category = this.categoryService.GetById(categoryId, true);

            if (category == null)
            {
                return this.NotFound("Category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.ToDictionary(x => x.Key, x => x.Value.Errors));
            }

            try
            {
                await this.categoryService.Update(category, categoryInput);
            }
            catch(Exception e)
            {
                this.logger.LogError(e.Message);
                this.logger.LogInformation(e.StackTrace);
                return this.BadRequest("An error occurred while trying to edit category!");
            }

            return this.Ok("Successfully edited category!");
        }
    }
}