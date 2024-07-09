using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _ordersService;

        public OrderController(IOrderService ordersService)
        {
            _ordersService= ordersService;
        }

        [HttpGet]
        [Route("/Orders/")]
        public List<Orders> GetOrders()
        {
            List<Orders> content = _ordersService.GetOrders();

            return content;
        }
        [HttpGet]
        [Route("/Order/{id}")]
        public Orders GetOrdersById(int id)
        {
            Orders content = _ordersService.GetOrderById(id);
            return content;
        }

        [HttpGet]
        [Route("/OrderProducts/{id}")]
        public List<OrderProducts> GetByOrderId2(int id)
        {
            return _ordersService.GetByOrderId(id);
        }
    }
}
