using Entities.Models;
using MongoDB.Driver;

namespace Repository
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
