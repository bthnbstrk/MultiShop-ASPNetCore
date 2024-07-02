using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Dtos.CategoryDtos;
using Shop.Catalog.Services.CategoryServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var data = await _categoryService.GetAllCategoryAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var data = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Successfull Inserted!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Successful Deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updatedCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updatedCategoryDto);
            return Ok("Successful Updated!");
        }

    }
}

