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
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        public OrderService(IOrderRepository ordersRepository, IUserService userService, ICartService cartService)
        {
            _orderRepository = ordersRepository;
            _userService = userService;
            _cartService = cartService;
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
            try
            {
                var user = _userService.GetUserByEmail(email);
                var cart = _cartService.GetCartByUserId(user.UserId);
                if (user!=null)
                {
                    Orders order = new Orders()
                    {
                        UserId = user.UserId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = user.Email,
                        UpdatedBy = user.Email,
                        Date = DateTime.Now,
                        Currency = cart.Currency,
                        TotalAmount = cart.TotalAmount,
                        Status = "Order Taken"
                    };
                    AddOrder(order);
                    return order;
                }
                throw new Exception("Couldn't Find User");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }

            return null;
        }
    }
}
