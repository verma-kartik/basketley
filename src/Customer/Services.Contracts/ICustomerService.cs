using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetCustomerss();

        public Task<long> GetCustomerCount();

        public Task<Customer> GetCustomerById(string customerId);

        public Task<bool> DeleteCustomer(string customerId);

        public Task<Customer> CreateCustomer(Customer customer);

        public Task<bool> UpdateCustomer(Customer customer);
    }
}
