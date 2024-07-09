using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CartProductController : Controller
    {
        private ICartProductService _cartProductsService;
        public CartProductController(ICartProductService cartProductsService)
        {
            _cartProductsService = cartProductsService;
        }
        [HttpGet]
        [Route("/CartProducts/")]
        public List<CartProducts> GetCartProducts()
        {
            List<CartProducts> content = _cartProductsService.GetCartProducts();

            return content;
        }
        [HttpGet]
        [Route("CartProduct/{id}")]
        public CartProducts GetCartProductById(int id)
        {
            CartProducts content = _cartProductsService.GetCartProductById(id);
            return content;
        }
    }
}
