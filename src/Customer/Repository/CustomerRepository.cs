using Contracts;
using Entities;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            var entity = new Customer()
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Company = customer.Company,
                CountryCode = customer.CountryCode,
                CountryName = customer.CountryName,
                Phone = customer.Phone,
                Email = customer.Email,
                EmailMarketingConsent = customer.EmailMarketingConsent,
                VerfiedEmail = customer.VerfiedEmail,
                Addresses = customer.Addresses
            };
            Create(entity);
        }

        public Customer GetCustomerById(int? customerId, bool trackChanges)
        {
            Customer? customer = FindByCondition(c => c.CustomerID.Equals(customerId), trackChanges).SingleOrDefault();
#pragma warning disable CS8603 // Possible null reference return.
            return customer;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public long GetCustomerCount()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            long count = RepositoryContext.Customers.Count();
#pragma warning restore CS8604 // Possible null reference argument.
            return count;

        }

        public IEnumerable<Customer> GetCustomers(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(c => c.FirstName).ToList();
        }

        public bool DeleteCustomer(int customerId, bool trackChanges)
        {
            Customer? customer = FindByCondition(c => c.CustomerID.Equals(customerId), trackChanges).SingleOrDefault();
            if (customer == null)
                return false;

            Delete(customer);
            return true; 

        }
    }
}
