using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Dtos.ProductImageDtos;
using Shop.Catalog.Services.ProductImageServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _productImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var data = await _productImageService.GetAllProductImageAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var data = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Successfull Inserted!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Successful Deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updatedProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updatedProductImageDto);
            return Ok("Successful Updated!");
        }

    }
}

