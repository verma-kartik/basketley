using Contracts;
using Entities;
using Repository;
using Services.Contracts;

namespace Services
{
    public sealed class CartService : ICartService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CartService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public Task<Cart> CreateCart(Cart cart)
        {
            return _repositoryManager.Cart.CreateCart(cart);
        }

        public async Task<bool> DeleteCart(string cartId)
        {
            return await _repositoryManager.Cart.DeleteCart(cartId);
        }

        public async Task<Cart> GetCart(string cartid)
        {
            return await _repositoryManager.Cart.GetCart(cartid);
        }

        public async Task<Cart> GetCartByCustomerId(int customerid)
        {
            return await _repositoryManager.Cart.GetCartByCustomerId(customerid);
        }

        public async Task<bool> UpdateCart(Cart cart)
        {
            return await _repositoryManager.Cart.UpdateCart(cart);
        }
    }
}
