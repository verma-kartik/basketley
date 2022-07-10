using Entities;

namespace Services.Contracts
{
    public interface ICartService
    {
        Task<Cart> CreateCart(Cart cart);

        Task<bool> DeleteCart(string cartId);

        Task<bool> UpdateCart(Cart cart);

        Task<Cart> GetCart(string cartid);

        Task<Cart> GetCartByCustomerId(int customerid);
    }
}
