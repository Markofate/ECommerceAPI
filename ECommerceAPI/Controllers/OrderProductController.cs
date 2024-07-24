using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Controllers
{
    public class OrderProductController : Controller
    {
        IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductsService)
        {
            _orderProductService = orderProductsService;
        }
        [HttpGet]
        [Route("/OrderProducts/")]
        public IActionResult GetOrderProducts()
        {
            var content = _orderProductService.GetOrderProducts();
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
        [Route("/OrderProduct/{id}")]
        public IActionResult GetOrderProductById(int id)
        {
            var content = _orderProductService.GetOrderProductById(id);
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
        [Route("/OrderProducts/{id}")]
        public IActionResult GetOrderProductsByOrderId(int id)
        {
            var content = _orderProductService.GetOrderProductsByOrderId(id);
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }

        [HttpPost]
        [Route("/AddProductsToOrder/{email}/{address}")]
        public List<OrderProducts> AddProductsToOrder(string email, string address)
        {
            return _orderProductService.AddProductsToOrder(email, address);
        }

    }
}
