namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
        IAddressService AddressService { get; }
    }
}
