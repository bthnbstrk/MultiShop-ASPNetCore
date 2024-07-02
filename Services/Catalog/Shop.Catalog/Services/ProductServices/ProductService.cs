using System;
using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.ProductDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;

namespace Shop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var updatedData = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, updatedData);
        }
    }
}

