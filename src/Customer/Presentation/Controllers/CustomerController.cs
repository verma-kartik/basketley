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
        public ActionResult GetCustomers()
        {
            try
            {
                var products =  _services.CustomerService.GetCustomers(trackChanges: false);
                return Ok(products);
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
        public ActionResult GetCustomerById(int customerId)
        {
            try
            {
                Customer? customerByID =  _services.CustomerService.GetCustomerById(customerId, trackChanges: false);   

                //if(customerByID.Addresses.Count > 0)
                //{
                //    var tempList = new List<Address>();
                //    foreach(var addressId in customerByID.Addresses)
                //    {
                //        var address = await _services.AddressService.GetAddressById(customerByID, addressId);
                //        if (address != null)
                //            tempList.Add(address);
                //    }
                //    customerByID.Addresses = tempList;  
                //}
                return Ok(customerByID);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{customerId}", Name = "DeleteCustomer")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public ActionResult DeleteCustomerById(int customerId)
        {
            try
            {
                bool isDeleted =  _services.CustomerService.DeleteCustomer(customerId, trackChanges: false);
                return Ok(isDeleted);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public ActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var createdCustomer =  _services.CustomerService.CreateCustomer(customer);

//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//                if (createdCustomer.Addresses.Count > 0)
//                {
//                    foreach (var variantID in createdProduct.ProductVariants)
//                    {
//                        if (await _services.ProductVariantService.GetVariantById(variantID) != null)
//                        {
//                            return StatusCode(500, "Internal Server Error.");
//                        }
//                        var variant = variantID;
//                        await _services.ProductVariantService.CreateVariant(variant);
//                    }
//                }
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(createdCustomer);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}
