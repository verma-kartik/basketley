using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductService _productService;

        //public ProductController(IProductService productService)
        //{
        //    _productService = productService ?? throw new ArgumentNullException(nameof(productService)); 
        //}

        private readonly IServiceManager _services;

        public ProductController(IServiceManager services)
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
    }
}
