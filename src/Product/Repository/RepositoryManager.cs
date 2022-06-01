using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductContext _productContext;
        private readonly IProductVariantContext _productVariantContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IProductVariantRepository> _productVariantRepository;

        public RepositoryManager(IProductContext productContext, IProductVariantContext productVariantContext)
        {
            _productContext = productContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(productContext));

            _productVariantContext = productVariantContext;
            _productVariantRepository = new Lazy<IProductVariantRepository>(() => new ProductVariantRepository(productVariantContext));
        }

        public IProductRepository Product => _productRepository.Value;
        public IProductVariantRepository ProductVariant => _productVariantRepository.Value; 
    }
}
