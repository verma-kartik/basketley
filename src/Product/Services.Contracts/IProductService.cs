using Entities.Models;
using Shared.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        public Task<(IEnumerable<Product>products, MetaData metaData)> GetProducts(ProductParameters productParameters);

        public Task<long> GetProductCount();

        public Task<Product> GetProductById(string productId);

        public Task<bool> DeleteProduct(string productId);

        public Task<Product> CreateProduct(Product product);

        public Task<bool> UpdateProduct(Product product);
    }
}
