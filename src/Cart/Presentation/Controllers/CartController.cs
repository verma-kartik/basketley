using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CartController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{cartId}", Name = "GetCart")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCartById(string cartId)
        {
            Cart? cartById = await _serviceManager.CartService.GetCart(cartId);
            return Ok(cartById);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateProduct([FromBody] Cart cart)
        {
            var createdCart = await _serviceManager.CartService.CreateCart(cart);

//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//            if (createdProduct.ProductVariants.Count > 0)
//            {
//                foreach (var variantID in createdProduct.ProductVariants)
//                {
//                    if (await _services.ProductVariantService.GetVariantById(variantID) != null)
//                    {
//                        return StatusCode(500, "Internal Server Error.");
//                    }
//                    var variant = variantID;
//                    await _services.ProductVariantService.CreateVariant(variant);
//                }
//            }
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(createdCart);
        }

        [HttpDelete("{cartId}", Name = "DeleteCart")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteCart(string cartId)
        {
            bool isDeleted = await _serviceManager.CartService.DeleteCart(cartId);
            return Ok(isDeleted);
        }

    }
}
