using System;
using Shop.Catalog.Dtos.ProductDtos;

namespace Shop.Catalog.Services.ProductServices
{
	public interface IProductService
	{
        Task<List<ResultProductDto>> GetAllProductAsync();

        Task CreateProductAsync(CreateProductDto createProductDto);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);

        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}

