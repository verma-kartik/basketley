using Contracts;
using Entities.Models;
using Repository;
using Services.Contracts;
using Shared.RequestParameters;

namespace Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ProductService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        
        public async Task<(IEnumerable<Product> products, MetaData metaData)> GetProducts(ProductParameters productParameters)
        {
            var productsWithMetaData = await _repositoryManager.Product.GetProducts(productParameters);
            return (products: productsWithMetaData, metaData: productsWithMetaData.MetaData);
        }

        public async Task<long> GetProductCount()
        {
            return await _repositoryManager.Product.GetProductCount();
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _repositoryManager.Product.GetProductById(productId);
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            return await _repositoryManager.Product.DeleteProduct(productId);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var createdProduct = await _repositoryManager.Product.CreateProduct(product);
            return createdProduct;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            return await _repositoryManager.Product.UpdateProduct(product);
        }

    }
}
