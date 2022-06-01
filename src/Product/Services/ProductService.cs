using Contracts;
using Entities.Models;
using Repository;
using Services.Contracts;

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

        
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = await _repositoryManager.Product.GetProducts();
                return products;
            }
            catch(Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetProducts)} " +
                    $"service method {ex}");
                throw;
            }
        }

        public async Task<long> GetProductCount()
        {
            try
            {
                return await _repositoryManager.Product.GetProductCount();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetProductCount)} " +
                    $"service method {ex}");
                throw;
            }
        }

        public async Task<Product> GetProductById(string productId)
        {
            try
            {
                return await _repositoryManager.Product.GetProductById(productId);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetProductById)} " +
                    $"service method {ex}. Product not found with ID {nameof(productId)}. Try again!");
                throw;
            }
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            try
            {
                return await _repositoryManager.Product.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(DeleteProduct)} " +
                    $"service method {ex}. Product not found with ID {nameof(productId)}. Try again!");
                throw;
            }
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var createdProduct = await _repositoryManager.Product.CreateProduct(product);
                return createdProduct;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(CreateProduct)} " +
                    $"service method {ex}. Cannot create product.");
                throw;
            }
        }

    }
}
