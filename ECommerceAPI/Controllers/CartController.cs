using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Controllers
{
    public class CartController : Controller
    {   
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        [Route("/Carts/")]
        public IActionResult GetCarts()
        {
            var content = _cartService.GetCarts();
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
        [Route("/Cart/{id}")]
        public IActionResult GetCartById(int id)
        {
            var content = _cartService.GetCartById(id);
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
        [Route("/User/{id}/Cart/")]
        public IActionResult GetCartByUserId(int id)
        {
            var content = _cartService.GetCartByUserId(id);
            if (content != null)
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
    }
}
