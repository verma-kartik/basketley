namespace Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IAddressRepository Address { get; }
        Task SaveAsync();
    }
}
