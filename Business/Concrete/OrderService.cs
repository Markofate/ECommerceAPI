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

namespace Business.Concrete
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        
        public OrderService(IOrderRepository ordersRepository, IUserRepository userRepository)
        {
            _orderRepository = ordersRepository;
            _userRepository = userRepository;
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

        public List<Orders> GetOrdersByUserEmail(string email)
        {
            var user = _userRepository.Get(u => u.Email == email);
            return _orderRepository.GetAll(o => o.UserId == user.UserId);
        }

        public Orders CreateOrder(string email, string address)
        {
            return _orderRepository.CreateOrder(email, address);
        }
    }
}
