using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class OrderProductController : Controller
    {
        IOrderProductService _orderProductsService;

        public OrderProductController(IOrderProductService orderProductsService)
        {
            _orderProductsService = orderProductsService;
        }
        [HttpGet]
        [Route("/OrderProducts/")]
        public List<OrderProducts> GetOrderProducts()
        {
            List<OrderProducts> content = _orderProductsService.GetOrderProducts();

            return content;
        }
        [HttpGet]
        [Route("/OrderProduct/{id}")]
        public OrderProducts GetOrderProductById(int id)
        {
            OrderProducts content = _orderProductsService.GetOrderProductById(id);
            return content;
        }
    }
}
