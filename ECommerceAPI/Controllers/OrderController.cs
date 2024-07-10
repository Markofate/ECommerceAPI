using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public List<Orders> GetOrders()
        {
            List<Orders> content = _orderService.GetOrders();

            return content;
        }
        [HttpGet]
        [Route("/Order/{id}")]
        public Orders GetOrdersById(int id)
        {
            return _orderService.GetOrderById(id);
        }
        [HttpGet]
        [Route("/User/{id}/order")]
        public List<Orders> GetOrdersByUserId(int id)
        {
            return _orderService.GetOrdersByUserId(id);
        }
    }
}
