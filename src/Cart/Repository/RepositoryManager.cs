namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ICartContext _cartContext;
        private readonly Lazy<ICartRepository> _cartRepository;

        public RepositoryManager(ICartContext cartContext)
        {
            _cartContext = cartContext;
            _cartRepository = new Lazy<ICartRepository>(
                () => new CartRepository(cartContext));
        }

        public ICartRepository Cart => _cartRepository.Value;
    }
}
