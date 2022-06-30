using Contracts;
using Entities;
using Services.Contracts;

namespace Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomerService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Customer CreateCustomer(Customer customer)
        {
            try
            {
                 _repository.Customer.CreateCustomer(customer);
                _repository.SaveAsync();
    
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(CreateCustomer)} " +
                    $"service method {ex}. Cannot create customer.");
                throw;
            }
        }

        public bool DeleteCustomer(int customerId, bool trackChanges)
        {
            try
            {
                return _repository.Customer.DeleteCustomer(customerId, trackChanges);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(DeleteCustomer)} " +
                    $"service method {ex}. Product not found with ID {nameof(customerId)}. Try again!");
                throw;
            }
        }

        public Customer GetCustomerById(int customerId, bool trackChanges)
        {
            try
            {
                return _repository.Customer.GetCustomerById(customerId, trackChanges);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCustomerById)} " +
                    $"service method {ex}. Customer not found with ID {nameof(customerId)}. Try again!");
                throw;
            }
        }

        public long GetCustomerCount()
        {
            try
            {
                return _repository.Customer.GetCustomerCount();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCustomerCount)} " +
                    $"service method {ex}");
                throw;
            }
        }

        public IEnumerable<Customer> GetCustomers(bool trackChanges)
        {
            try
            {
                var customers =  _repository.Customer.GetCustomers(trackChanges);
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCustomers)} " +
                    $"service method {ex}");
                throw;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
