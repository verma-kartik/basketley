using Entities.Models;
using MongoDB.Driver;
using Repository;

namespace Product.API.ContextFactory
{
    public class ProductVariantContextFactory : IProductVariantContext
    {
        public ProductVariantContextFactory(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            ProductVariants = database.GetCollection<ProductVariant>(configuration.GetValue<string>("DatabaseSettings:CollectionName_2"));
        }

        public IMongoCollection<ProductVariant> ProductVariants { get; }
    }
}
