using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.RequestParameters;
using System.Net;
using System.Text.Json;

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
        public async Task<ActionResult<IEnumerable<ProductVariant>>> GetVariants([FromQuery]ProductVariantParameters productVariantParameters)
        {
            var (variants, metaData) = await _services.ProductVariantService.GetVariants(productVariantParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(variants);
        }

        [HttpGet("{variantId}", Name = "GetVariant")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVariant>> GetvariantById(string variantId)
        {
            var variantByID = await _services.ProductVariantService.GetVariantById(variantId);
            return Ok(variantByID);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductVariant), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVariant>> CreateVariant([FromBody] ProductVariant variant)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdVariant = await _services.ProductVariantService.CreateVariant(variant);
            return createdVariant;
        }

        [HttpDelete("{variantId}", Name = "DeleteVariant")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteVariant(string variantId)
        {
            bool isDeleted = await _services.ProductVariantService.DeleteVariant(variantId);
            return Ok(isDeleted);
        }
    }
}
