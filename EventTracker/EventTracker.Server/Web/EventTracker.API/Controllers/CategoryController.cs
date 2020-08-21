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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryService<Category> categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService<Category> categoryService)
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
    }
}