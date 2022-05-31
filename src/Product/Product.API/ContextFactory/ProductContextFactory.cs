using MongoDB.Driver;
using Repository;

namespace Product.API.ContextFactory
{
    public class ProductContextFactory : IProductContext
    {
        public ProductContextFactory(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Entities.Models.Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            ContextSeed.SeedData(Products);
        }

        public IMongoCollection<Entities.Models.Product> Products { get; }
       
    }
}
