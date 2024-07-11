using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService ordersService)
        {
            _orderService= ordersService;
        }

        [HttpGet]
        [Route("/Orders/")]
        public IActionResult GetOrders()
        {
            var content = _orderService.GetOrders();
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
        [Route("/Order/{id}")]
        public IActionResult GetOrdersById(int id)
        {
            var content = _orderService.GetOrderById(id);
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
        [Route("/User/{id}/order")]
        public IActionResult GetOrdersByUserId(int id)
        {
            var content = _orderService.GetOrdersByUserId(id);
            if (!content.IsNullOrEmpty())
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
