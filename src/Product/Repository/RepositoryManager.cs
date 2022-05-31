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
        private readonly Lazy<IProductRepository> _productRepository;

        public RepositoryManager(IProductContext productContext)
        {
            _productContext = productContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(productContext));
        }

        public IProductRepository Product => _productRepository.Value;
    }
}
