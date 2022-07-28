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

        public bool DeleteAddress(int customerId, string addressId)
        {

            var toBeDeleted = FindByCondition(a => a.CustomerId.Equals(customerId)
            && a.Id.Equals(addressId), false).Single();

            if (toBeDeleted == null)
                return false;

            Delete(toBeDeleted);
            return true;
        }

        public async Task<Address> GetAddress(int customerId, string addressId, bool trackChanges)
        {

            Address? address =  await FindByCondition(a => a.CustomerId.Equals(customerId) && a.Id.Equals(addressId), trackChanges)
                .SingleOrDefaultAsync();

            return address;

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
