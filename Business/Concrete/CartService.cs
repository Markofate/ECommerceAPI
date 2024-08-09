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
using Serilog;

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
            try
            {
                return _cartRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Carts GetCartById(int id)
        {
            try
            {
                return _cartRepository.Get(c => c.CartId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Carts GetCartByUserId(int userId)
        {
            try
            {
                return _cartRepository.Get(c => c.UserId == userId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }


        public Carts CreateCart(string email)
        {
            try
            {
                Log.Warning("New Cart Created By: {@email}", email);
                return _cartRepository.CreateCart(email);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }
    }
}
