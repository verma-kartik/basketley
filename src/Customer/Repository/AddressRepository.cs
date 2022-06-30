using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAddressForcustomer(int customerId, Address address)
        {
            address.CustomerId = customerId;
            Create(address);
        }

        public void DeleteAddress(int customerId, Address address)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var toBeDeleted = FindByCondition(a => a.CustomerId.Equals(customerId)
            && a.Id.Equals(address.Id), false);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            Delete((Address)toBeDeleted);
        }

        public async Task<Address> GetAddress(int customerId, string addressId, bool trackChanges)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Address? address =  await FindByCondition(a => a.CustomerId.Equals(customerId) && a.Id.Equals(addressId), trackChanges)
                .SingleOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return address;
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public async Task<IEnumerable<Address>> GetAddresses(int customerId, bool trackChanges)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await FindByCondition(a => a.CustomerId.Equals(customerId), trackChanges)
                .OrderBy(a => a.Id)
                .ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
