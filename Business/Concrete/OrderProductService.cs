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
        private readonly IOrderProductRepository _orderProductsRepository;
        public OrderProductService(IOrderProductRepository orderProductsRepository)
        {
            _orderProductsRepository = orderProductsRepository;
        }
        public void AddOrderProduct(OrderProducts orderProducts)
        {
            _orderProductsRepository.Add(orderProducts);
        }
        public void UpdateProduct(OrderProducts orderProducts)
        {
            _orderProductsRepository.Update(orderProducts);
        }
        public void DeleteProduct(OrderProducts orderProducts)
        {
            _orderProductsRepository.Delete(orderProducts);
        }
        public List<OrderProducts> GetOrderProducts()
        {
            return _orderProductsRepository.GetAll();
        }

        public OrderProducts GetOrderProductById(int id)
        {
            return _orderProductsRepository.Get(op=>op.OrderProductId==id);
        }
    }
}
