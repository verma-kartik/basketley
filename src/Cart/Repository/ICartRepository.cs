using Entities;

namespace Repository
{
    public interface ICartRepository
    {
        Task<Cart> CreateCart(Cart cart);

        Task<bool> DeleteCart(string cartId);

        Task<bool> UpdateCart(Cart cart);

        Task<Cart> GetCart(string cartid);

        Task<Cart> GetCartByCustomerId(int customerid);
    }
}
