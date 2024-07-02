using System;
using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.ProductDetailDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;

namespace Shop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {

        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }


        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var updatedData = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, updatedData);
        }
    }
}

