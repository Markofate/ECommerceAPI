using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CartController : Controller
    {   
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        [Route("/Carts/")]
        public List<Carts> GetCarts()
        {
            List<Carts> content = _cartService.GetCarts();

            return content;
        }
        [HttpGet]
        [Route("/Cart/{id}")]
        public Carts GetCartById(int id)
        {
            Carts content = _cartService.GetCartById(id);
            return content;
        }
    }
}
