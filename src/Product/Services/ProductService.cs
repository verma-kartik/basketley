using Contracts;
using Entities.Models;
using Repository;
using Services.Contracts;

namespace Services
{
    public sealed class ProductService : IProductService
    {
        //private readonly IProductRepository _productRepository;
        //private readonly ILoggerManager _logger;

        //public ProductService(IProductRepository productRepository, ILoggerManager logger)
        //{
        //    _productRepository = productRepository;
        //    _logger = logger;
        //}

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


    }
}
