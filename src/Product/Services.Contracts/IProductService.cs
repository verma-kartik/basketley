using Entities.Models;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        public Task<(IEnumerable<Product>products, MetaData metaData)> GetProducts(ProductParameters productParameters);

        public Task<long> GetProductCount();

        public Task<Product> GetProductById(string productId);

        public Task<bool> DeleteProduct(string productId);

        public Task<Product> CreateProduct(Product product);
    }
}
