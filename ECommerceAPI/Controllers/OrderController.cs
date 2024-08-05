using Business.Abstract;
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
        [Route("/Order/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var content = _orderService.GetOrderById(orderId);
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
        [Route("/User/{email}/orders")]
        public IActionResult GetOrdersByUserEmail(string email)
        {
            var content = _orderService.GetOrdersByUserEmail(email);
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
