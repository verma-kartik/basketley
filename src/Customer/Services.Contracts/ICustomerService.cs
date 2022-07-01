using Entities;

namespace Services.Contracts
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetCustomers(bool trackChanges);

        public long GetCustomerCount();

        public Customer GetCustomerById(int customerId, bool trackChanges);

        public Customer CreateCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);
    }
}
