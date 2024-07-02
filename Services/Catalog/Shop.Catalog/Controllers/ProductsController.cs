using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Dtos.ProductDtos;
using Shop.Catalog.Services.ProductServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var data = await _productService.GetAllProductAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var data = await _productService.GetByIdProductAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Successfull Inserted!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Successful Deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updatedProductDto)
        {
            await _productService.UpdateProductAsync(updatedProductDto);
            return Ok("Successful Updated!");
        }

    }
}

