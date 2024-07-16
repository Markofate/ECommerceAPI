using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly Lazy<IUserService> _userService;

        public CartService(ICartRepository cartRepository, Lazy<IUserService> userService)
        {
            _cartRepository = cartRepository;
            _userService = userService;
        }
        public bool AddCart(Carts cart)
        {
            if (cart != null)
            {
                _cartRepository.Add(cart);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool UpdateCart(Carts cart)
        {
            if (cart != null)
            {
                _cartRepository.Update(cart);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool DeleteCart(Carts cart)
        {
            if (cart != null)
            {
                _cartRepository.Delete(cart);
                return true;
            }
            else
            {
                return false;
            }
            
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

        public Users GetUserByEmail(string email)
        {
            return _userService.Value.GetUserByEmail(email);
        }

        public Carts CreateCart(string email)
        {
            try
            {
                var user = _userService.Value.GetUserByEmail(email);
                if (user != null)
                {
                    Carts cart = new Carts(){UserId = user.UserId, CreatedBy = user.Email, UpdatedBy = user.Email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now};
                    AddCart(cart);
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
