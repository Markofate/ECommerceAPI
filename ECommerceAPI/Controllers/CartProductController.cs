using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Controllers
{
    public class CartProductController : Controller
    {
        private ICartProductService _cartProductService;
        public CartProductController(ICartProductService cartProductsService)
        {
            _cartProductService = cartProductsService;
        }
        [HttpGet]
        [Route("/CartProducts/")]
        public IActionResult GetCartProducts()
        {
           var content = _cartProductService.GetCartProducts();
           if (!content.IsNullOrEmpty())
           {
               return Ok(content);
           }
           else
           {
               return BadRequest("No Products To show");
           }
        }
        [HttpGet]
        [Route("CartProduct/{id}")]
        public IActionResult GetCartProductById(int id)
        {
            var content = _cartProductService.GetCartProductById(id);
            if (content != null)
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
        [HttpGet]
        [Route("CartProducts/{email}")]
        public IActionResult GetCartProductsByEmail(string email)
        {
            var content = _cartProductService.GetCartProductsByEmail(email);
            if (content != null)
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
        /*
        [HttpGet]
        [Route("/User/{id}/Cart/Products")] product controllerda
        public IActionResult GetCartProductsByUserId(int id)
        {
            var content = _cartProductService.GetCartProductsByUserId(id);
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }if (email != null)
            {
                var content = _cartProductService.AddProductToCart(productId, quantity, email);
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }*/

        [HttpPost("AddProductToCart/{productId}/{email}/{quantity}")]
        public IActionResult AddProductToCart(int productId, int quantity, string email)
        {
                if (email != null)
                {
                    var content = _cartProductService.AddProductToCart(productId, quantity, email);
                    return Ok(content);
                }
                return BadRequest();
        }



        [HttpDelete("RemoveProductFromCart/{productId}/{email}")]
        public IActionResult RemoveProductFromCart(int productId, string email)
        {
            if (email != null)
            {
                return Ok(_cartProductService.RemoveProductFromCart(productId, email));
            }
            else
            {
                return BadRequest(400);
            }
        }
    }
}
