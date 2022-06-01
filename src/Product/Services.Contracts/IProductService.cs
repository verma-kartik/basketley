using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<long> GetProductCount();

        public Task<Product> GetProductById(string productId);

        public Task<bool> DeleteProduct(string productId);

        public Task<Product> CreateProduct(Product product);
    }
}
