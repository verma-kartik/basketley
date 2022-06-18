using Entities;

namespace Contracts
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses(string customerId, bool trackChanges);

        Task<Address> GetAddress(string customerId, string addressId, bool trackChanges);

        void CreateAddressForcustomer(string customerId, Address address);

        void DeleteAddress(string customerId, Address address);
    }
}
