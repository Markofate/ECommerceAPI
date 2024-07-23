using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class OrderRepository : GenericRepository<Orders, ECommerceDbContext>, IOrderRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;

        public OrderRepository(IUserRepository userRepository, ICartRepository cartRepository)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
        }
        public Orders CreateOrder(string email)
        {
            try
            {
                var user = _userRepository.Get(u=>u.Email==email);
                var cart = _cartRepository.Get(c=>c.UserId==user.UserId);
                if (user != null)
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
                    Add(order);
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