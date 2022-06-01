using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/products/{productId}/variants")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ProductVariantController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductVariant>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductVariant>>> GetVariants()
        {
            try
            {
                var variants = await _services.ProductVariantService.GetVariants();
                return Ok(variants);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpGet("{variantId}", Name = "GetVariant")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVariant>> GetvariantById(string variantId)
        {
            try
            {
                var variantByID = await _services.ProductVariantService.GetVariantById(variantId);
                return Ok(variantByID);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductVariant), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVariant>> CreateVariant([FromBody] ProductVariant variant)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var createdVariant = await _services.ProductVariantService.CreateVariant(variant);
                return createdVariant;
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpDelete("{variantId}", Name = "DeleteVariant")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteVariant(string variantId)
        {
            try
            {
                bool isDeleted = await _services.ProductVariantService.DeleteVariant(variantId);
                return Ok(isDeleted);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}
