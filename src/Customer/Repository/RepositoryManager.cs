using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
		private readonly Lazy<ICustomerRepository> _customerRepository;
		private readonly Lazy<IAddressRepository> _addressRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_context = repositoryContext;
			_customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(repositoryContext));
			_addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(repositoryContext));
		}

		public IAddressRepository Address => _addressRepository.Value;

        public ICustomerRepository Customer => _customerRepository.Value;

		public async Task SaveAsync() => await _context.SaveChangesAsync();
	}
}
