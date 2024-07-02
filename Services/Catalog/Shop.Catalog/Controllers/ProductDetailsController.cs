using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Dtos.ProductDetailDtos;
using Shop.Catalog.Services.ProductDetailServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var data = await _productDetailService.GetAllProductDetailAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var data = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Successfull Inserted!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Successful Deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updatedProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updatedProductDetailDto);
            return Ok("Successful Updated!");
        }

    }
}

