using Entities;

namespace Contracts
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses(int customerId, bool trackChanges);

        Task<Address> GetAddress(int customerId, int addressId, bool trackChanges);

        void CreateAddressForcustomer(int customerId, Address address);

        bool DeleteAddress(int customerId, int addressId);
    }
}
