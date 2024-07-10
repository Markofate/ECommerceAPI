using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public List<OrderProducts> GetOrderProducts()
        {
            List<OrderProducts> content = _orderProductService.GetOrderProducts();

            return content;
        }
        [HttpGet]
        [Route("/OrderProduct/{id}")]
        public OrderProducts GetOrderProductById(int id)
        {
            OrderProducts content = _orderProductService.GetOrderProductById(id);
            return content;
        }
        [HttpGet]
        [Route("/OrderProducts/{id}")]
        public List<OrderProducts> GetOrderProductsByOrderId(int id)
        {
            return _orderProductService.GetOrderProductsByOrderId(id);
        }
    }
}
