using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CustomerController(IServiceManager service)
        {
            _services = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                var customers =  _services.CustomerService.GetCustomers(trackChanges: false);
                foreach(var customer in customers)
                {
#pragma warning disable CS8629 // Nullable value type may be null.
                    var addresses = await _services.AddressService.GetAddresses((int)customer.CustomerID, trackChanges: false);
#pragma warning restore CS8629 // Nullable value type may be null.
                    if (addresses.Any())
                    {
                        customer.Addresses = (List<Address>?)addresses;
                    }          
                }
                return Ok(customers);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("count")]
        [HttpGet]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        public ActionResult GetCount()
        {
            try
            {
                var count =  _services.CustomerService.GetCustomerCount();
                return Ok(count);
            }
            catch 
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{customerId}", Name = "GetCustomer")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCustomerById(int customerId)
        {
            try
            {
                Customer customerByID =  _services.CustomerService.GetCustomerById(customerId, trackChanges: false);

                var addresses = await _services.AddressService.GetAddresses(customerId, trackChanges: false);
                if(addresses.Any())
                {
                    customerByID.Addresses = (List<Address>?)addresses;
                }
                return Ok(customerByID);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var createdCustomer =  _services.CustomerService.CreateCustomer(customer);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (createdCustomer.Addresses.Count > 0)
                {
                    foreach (var address in createdCustomer.Addresses)
                    {
#pragma warning disable CS8629 // Nullable value type may be null.
                        if (await _services.AddressService.GetAddress((int)createdCustomer.CustomerID, address.Id, trackChanges: false) != null)
                        {
                            return StatusCode(500, "Internal Server Error.");
                        }
#pragma warning restore CS8629 // Nullable value type may be null.
                        await _services.AddressService.CreateAddressForCustomer((int)createdCustomer.CustomerID, address);
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(createdCustomer);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}
