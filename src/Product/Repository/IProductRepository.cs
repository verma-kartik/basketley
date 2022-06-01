using Entities.Models;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(string productId);

        Task<IEnumerable<Product>> GetProductByName(string productName);

        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        Task<Product> CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(string productId);

        Task<long> GetProductCount();
    }
}
