using System.Net.Mail;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
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
               return BadRequest(400);
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
        [Route("/User/Cart/{id}/Products")]
        public IActionResult GetCartProductsByCartId(int id)
        {
            var content = _cartProductService.GetCartProductsByCartId(id);
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }

        [HttpPost("AddProductToCart/{productId}/{email}/{quantity}")]
        public IActionResult AddProductToCart(int productId, int quantity, string email)
        {
            if (email != null)
            {
                return Ok(_cartProductService.AddProductToCart(productId, quantity, email));
            }
            else
            {
                return BadRequest(400);
            }
            
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
