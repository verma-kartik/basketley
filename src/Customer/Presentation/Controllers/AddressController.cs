using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/customers/{customerId}/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AddressController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Address>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAddresses(int customerId)
        {
            try
            {
                var addressess = await _service.AddressService.GetAddresses(customerId, trackChanges: false);
                return Ok(addressess);
            }
            catch 
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{addressId}", Name = "GetAddress")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAddress(int customerId, int addressId)
        {
            try
            {
                Address? addressbyId = await _service.AddressService.GetAddress(customerId, addressId, trackChanges: false);
                return Ok(addressbyId);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{addressId}", Name = "DeleteAddress")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteAddress(int customerId, int addressId)
        {
            try
            {
                bool isDeleted = await _service.AddressService.DeleteAddress(customerId, addressId);
                return Ok(isDeleted);
            }
            catch 
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Address), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateAddress(int customerId, [FromBody]Address address)
        {
            try
            {
                var createdAddress = await _service.AddressService.CreateAddressForCustomer(customerId, address);
                return Ok(createdAddress);
            }
            catch 
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}
