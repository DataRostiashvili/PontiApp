using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.CategoryServices;
using PontiApp.Models.DTOs;
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
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                await _categoryService.Add(categoryDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route(nameof(DeleteCategory))]
        public async Task<ActionResult> DeleteCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                await _categoryService.Delete(categoryDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategory()
        {
            try
            {
                List<CategoryDTO> categoryDTOs = await _categoryService.GetAll();
                return Ok(categoryDTOs);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
