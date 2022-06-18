using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public Customer GetCustomerById(string? customerId, bool trackChanges)
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
    }
}
