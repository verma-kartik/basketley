using Entities.Models;
using MongoDB.Driver;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        protected IProductContext _productContext;

        public ProductRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _productContext.Products.InsertOneAsync(product);

            return product;
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, productId);

            DeleteResult deleteResult = await _productContext
                .Products
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _productContext
                .Products
                .Find(p => p.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, productName);

            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<long> GetProductCount()
        {
            return await _productContext.Products.Find(p => true).CountDocumentsAsync();
        }

        public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters)
        {
            var products = await _productContext.Products
                .Find(p => p.Price >= productParameters.MinPrice && p.Price <= productParameters.MaxPrice)
                .SortBy(p => p.Name)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _productContext
                .Products
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
