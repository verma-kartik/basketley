using Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customersService;
        private readonly Lazy<IAddressService> _addressService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _customersService = new Lazy<ICustomerService>(() =>
            new CustomerService(repositoryManager, logger));

            _addressService = new Lazy<IAddressService>(() =>
            new AddressService(repositoryManager, logger));
        }   

        public ICustomerService CustomerService => _customersService.Value;
        public IAddressService AddressService => _addressService.Value;
    }
}
