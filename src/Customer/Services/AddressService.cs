using Contracts;
using Services.Contracts;

namespace Services
{
    public sealed class AddressService : IAddressService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public AddressService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
