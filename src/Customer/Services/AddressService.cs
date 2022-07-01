using Contracts;
using Entities;
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

        public async Task<Address> CreateAddressForCustomer(int customerId, Address address)
        {
            try
            {
                _repository.Address.CreateAddressForcustomer(customerId, address);
                await _repository.SaveAsync();

                return address;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(CreateAddressForCustomer)} " +
                    $"service method {ex}. Cannot create address.");
                throw;
            }
        }

        public async Task<bool> DeleteAddress(int customerId, int addressId)
        {
            try
            {
                var deleted =  _repository.Address.DeleteAddress(customerId, addressId);
                await _repository.SaveAsync();

                return deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(DeleteAddress)} " +
                                    $"service method {ex}. Address not found with ID {nameof(addressId)}. Try again!");
                throw;
            }
        }

        public async Task<Address> GetAddress(int customerId, int addressId, bool trackChanges)
        {
            try
            {
                return await _repository.Address.GetAddress(customerId, addressId, trackChanges);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAddress)} " +
                                    $"service method {ex}. Address not found with ID {nameof(addressId)}. Try again!");
                throw;
            }
        }

        public async Task<IEnumerable<Address>> GetAddresses(int customerId, bool trackChanges)
        {
            try
            {
                return await _repository.Address.GetAddresses(customerId, trackChanges);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAddress)} " +
                                    $"service method {ex}");
                throw;
            }
        }
    }
}
