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
        
        public List<Orders> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public Orders GetOrderById(int id)
        {
            return _orderRepository.Get(o=>o.OrderId==id);
        }
        public Orders GetOrderByUserId(int id)
        {
            return _orderRepository.Get(o => o.UserId == id);
        }

        public List<Orders> GetOrdersByUserId(int id)
        {
            return _orderRepository.GetAll(o => o.UserId == id);
        }

        public Orders CreateOrder(string email)
        {
            return _orderRepository.CreateOrder(email);
        }
    }
}
