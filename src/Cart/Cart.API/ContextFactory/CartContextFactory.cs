using MongoDB.Driver;
using Repository;

namespace Cart.API.ContextFactory
{
    public class CartContextFactory : ICartContext
    {
        public CartContextFactory(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Carts = database.GetCollection<Entities.Cart>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //ContextSeed.SeedData(Products);
        }

        public IMongoCollection<Entities.Cart> Carts { get; }
    }
}
