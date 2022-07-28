using Entities;

namespace Services.Contracts
{
    public interface IAddressService
    {
        public Task<IEnumerable<Address>> GetAddresses(int customerId, bool trackChanges);

        public Task<Address> GetAddress(int customerId, string addressId, bool trackChanges);

        public Task<bool> DeleteAddress(int customerId, string addressId);

        public Task<Address> CreateAddressForCustomer(int customerId, Address address);
    }
}
