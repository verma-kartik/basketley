using Entities.Models;
using MongoDB.Driver;

namespace Repository
{
    public interface IProductVariantContext
    {
        IMongoCollection<ProductVariant> ProductVariants { get; }
    }
}
