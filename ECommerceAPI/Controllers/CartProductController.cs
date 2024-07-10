using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public List<CartProducts> GetCartProducts()
        {
            List<CartProducts> content = _cartProductService.GetCartProducts();

            return content;
        }
        [HttpGet]
        [Route("CartProduct/{id}")]
        public CartProducts GetCartProductById(int id)
        {
            CartProducts content = _cartProductService.GetCartProductById(id);
            return content;
        }
        [HttpGet]
        [Route("/User/Cart/{id}/Products")]
        public List<CartProducts> GetCartProductsByCartId(int id)
        {
            return _cartProductService.GetCartProductsByCartId(id);
        }

        [HttpPost("AddProductToCart/{productId}/{cartId}/{quantity}")]
        public void AddProductToCart(int productId, int cartId, int quantity)
        {
            _cartProductService.AddProductToCart(productId, cartId, quantity);
        }

    }
}
