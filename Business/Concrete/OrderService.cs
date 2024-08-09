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
using Serilog;

namespace Business.Concrete
{
    public class OrderService : IOrderService
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
            try
            {
                return _orderRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Orders GetOrderById(int id)
        {
            try
            {
                return _orderRepository.Get(o => o.OrderId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }
        public Orders GetOrderByUserId(int id)
        {
            try
            {
                return _orderRepository.Get(o => o.UserId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public List<Orders> GetOrdersByUserEmail(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                return _orderRepository.GetAll(o => o.UserId == user.UserId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Orders CreateOrder(string email, string address)
        {
            try
            {
                return _orderRepository.CreateOrder(email, address);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }
    }
}
