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
            var entity = new Address() {
                Id = address.Id,
                Address1 = address.Address1,
                Address2 = address.Address2,
                District = address.District,
                State = address.State,
                City = address.City,
                Country = address.Country,
                CountryCode = address.CountryCode,
                Zip = address.Zip,
                CustomerId = customerId
            };
            Create(entity);
        }

        public bool DeleteAddress(int customerId, int addressId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var toBeDeleted = FindByCondition(a => a.CustomerId.Equals(customerId)
            && a.Id.Equals(addressId), false).SingleOrDefault();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (toBeDeleted == null)
                return false;

            Delete(toBeDeleted);
            return true;
        }

        public async Task<Address> GetAddress(int customerId, int addressId, bool trackChanges)
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
