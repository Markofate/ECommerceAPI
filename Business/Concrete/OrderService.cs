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
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository ordersRepository)
        {
            _orderRepository = ordersRepository;
        }
        public void AddOrder(Orders order)
        {
            _orderRepository.Add(order);
        }
        public void UpdateOrder(Orders order)
        {
            _orderRepository.Update(order);
        }
        public void DeleteOrder(Orders order)
        {
            _orderRepository.Delete(order);
        }

        public List<Orders> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public Orders GetOrderById(int id)
        {
            return _orderRepository.Get(o=>o.OrderId==id);
        }

        public List<Orders> GetOrdersByUserId(int id)
        {
            return _orderRepository.GetAll(o => o.UserId == id);
        }

    }
}
