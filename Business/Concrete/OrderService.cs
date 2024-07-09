using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Entities.Conrete;

namespace Business.Concrete
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _ordersRepository;
        public OrderService(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public void AddOrder(Orders order)
        {
            _ordersRepository.Add(order);
        }
        public void UpdateOrder(Orders order)
        {
            _ordersRepository.Update(order);
        }
        public void DeleteOrder(Orders order)
        {
            _ordersRepository.Delete(order);
        }

        public List<Orders> GetOrders()
        {
            return _ordersRepository.GetAll();
        }

        public Orders GetOrderById(int id)
        {
            return _ordersRepository.Get(o=>o.OrderId==id);
        }

        public List<OrderProducts> GetByOrderId(int userId)
        {
            return _ordersRepository.GetByOrderId(userId);
        }

    }
}
