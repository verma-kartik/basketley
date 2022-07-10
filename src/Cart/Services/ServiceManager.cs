using Services.Contracts;
using Repository;
using Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICartService> _cartService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _cartService = new Lazy<ICartService>(
                () => new CartService(repositoryManager, loggerManager));            
        }

        public ICartService CartService => _cartService.Value;
    }
}
