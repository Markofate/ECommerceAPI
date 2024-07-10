using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderProductService(IOrderProductRepository orderProductsRepository)
        {
            _orderProductRepository = orderProductsRepository;
        }
        public void AddOrderProduct(OrderProducts orderProducts)
        {
            _orderProductRepository.Add(orderProducts);
        }
        public void UpdateOrderProduct(OrderProducts orderProducts)
        {
            _orderProductRepository.Update(orderProducts);
        }
        public void DeleteOrderProduct(OrderProducts orderProducts)
        {
            _orderProductRepository.Delete(orderProducts);
        }
        public List<OrderProducts> GetOrderProducts()
        {
            return _orderProductRepository.GetAll();
        }

        public OrderProducts GetOrderProductById(int id)
        {
            return _orderProductRepository.Get(op=>op.OrderProductId==id);
        }

        public List<OrderProducts> GetOrderProductsByOrderId(int id)
        {
            return _orderProductRepository.GetAll(op=>op.OrderId==id);
        }
    }
}
