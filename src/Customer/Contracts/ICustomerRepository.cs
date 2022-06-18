using Entities;

namespace Contracts
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(string customerId, bool trackChanges);

        IEnumerable<Customer> GetCustomers(bool trackChanges);

        void CreateCustomer(Customer customer);

        long GetCustomerCount();
    }
}
