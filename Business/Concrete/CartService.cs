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

        public CartService(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
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
            return _cartRepository.CreateCart(email);
        }
    }
}
