using Entities;
using MongoDB.Driver;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartContext _context;

        public CartRepository(ICartContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateCart(Cart cart)
        {
            await _context.Carts.InsertOneAsync(cart);
            return cart;
        }

        public async Task<bool> DeleteCart(string cartId)
        {
            FilterDefinition<Cart> filter = Builders<Cart>.Filter
                .Eq(c => c.CartId, cartId);

            DeleteResult deleteResult = await _context.Carts.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Cart> GetCart(string cartid)
        {
            return await _context
                .Carts
                .Find(c => c.CartId == cartid)
                .FirstOrDefaultAsync();
        }

        public async Task<Cart> GetCartByCustomerId(int customerid)
        {
            return await _context
                .Carts
                .Find(c => c.CustomerId == customerid)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCart(Cart cart)
        {
            var updateResult = await _context
                .Carts
                .ReplaceOneAsync(filter: g => g.CartId == cart.CartId, replacement: cart);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
