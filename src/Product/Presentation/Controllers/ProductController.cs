using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ProductsController(IServiceManager services)
        {
            _services = services;   
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _services.ProductService.GetProducts();
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [Route("count")]
        [HttpGet]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> GetCount()
        {
            try
            {
                var count = await _services.ProductService.GetProductCount();
                return Ok(count);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string productId)
        {
            try
            {
                var productByID = await _services.ProductService.GetProductById(productId);
                return Ok(productByID);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

    }
}
