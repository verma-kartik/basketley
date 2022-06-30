using Entities;

namespace Contracts
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int? customerId, bool trackChanges);

        IEnumerable<Customer> GetCustomers(bool trackChanges);

        void CreateCustomer(Customer customer);

        long GetCustomerCount();

        bool DeleteCustomer(int customerId, bool trackChanges);
    }
}
