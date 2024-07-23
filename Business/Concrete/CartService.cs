using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.Identity.Client;

namespace Business.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public CartService(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }
        public List<Carts> GetCarts()
        {
            return _cartRepository.GetAll();
        }

        public Carts GetCartById(int id)
        {
           return _cartRepository.Get(c=>c.CartId==id);
        }

        public Carts GetCartByUserId(int userId)
        {
            return _cartRepository.Get(c=>c.UserId==userId);
        }


        public Carts CreateCart(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                if (user != null)
                {
                    Carts cart = new Carts(){UserId = user.UserId, CreatedBy = user.Email, UpdatedBy = user.Email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now};
                    _cartRepository.Add(cart);
                    return cart;
                }
                else
                {
                    throw new Exception("Couldn't Find User");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}
