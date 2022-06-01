using Contracts;
using Repository;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductVariantService> _productVariantService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, loggerManager));
            _productVariantService = new Lazy<IProductVariantService>(() => new ProductVariantService(repositoryManager, loggerManager));
        }

        public IProductService ProductService => _productService.Value;
        public IProductVariantService ProductVariantService => _productVariantService.Value;
    }
}
