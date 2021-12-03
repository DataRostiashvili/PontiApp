using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.CategoryServices;
using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route(nameof(CreateCategory))]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryRequest categoryRequest)
        {
            await _categoryService.Add(categoryRequest);
            return Ok();
        }

        [HttpDelete]
        [Route(nameof(DeleteCategory))]
        public async Task<ActionResult> DeleteCategory([FromBody] CategoryRequest categoryRequest)
        {

            await _categoryService.Delete(categoryRequest);
            return Ok();

        }

        [HttpGet]
        [Route(nameof(GetAllCategory))]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAllCategory()
        {

            var categoryDTOs = await _categoryService.GetAll();
            return Ok(new { isSuccess = true, categories = categoryDTOs });

        }
    }
}
