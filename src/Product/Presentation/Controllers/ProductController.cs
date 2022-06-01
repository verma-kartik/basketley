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
                
                if(productByID.ProductVariants.Count > 0)
                {
                    var tempList = new List<ProductVariant>();
                    foreach(var variantId in productByID.ProductVariants)
                    {
                        var variant = await _services.ProductVariantService.GetVariantById(variantId);
                        if(variant != null)
                            tempList.Add(variant);
                    }
                    productByID.ProductVariantList = tempList;
                }
                return Ok(productByID);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            //try
            //{ 
                var createdProduct = await _services.ProductService.CreateProduct(product);

                if(createdProduct.ProductVariants.Count > 0)
                {
                    foreach (var variantID in createdProduct.ProductVariants)
                    {
                        if (await _services.ProductVariantService.GetVariantById(variantID) != null)
                        {
                             return StatusCode(500, "Internal Server Error.");
                    }
                        var variant = variantID;
                        await _services.ProductVariantService.CreateVariant(variant);
                    }
                }
                return Ok(createdProduct);
            //}
            //catch
            //{
            //    return StatusCode(500, "Internal Server Error.");
            //}
        }

        [HttpDelete("{productId}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteProductById(string productId)
        {
            try
            {
                bool isDeleted = await _services.ProductService.DeleteProduct(productId);
               return Ok(isDeleted);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error.");
            }
        }


    }
}
