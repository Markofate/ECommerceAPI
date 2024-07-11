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
        private readonly IUserService _userService;

        public CartService(ICartRepository cartRepository, IUserService userService)
        {
            _cartRepository = cartRepository;
            _userService = userService;
        }
        public void AddCart(Carts cart)
        {
            _cartRepository.Add(cart);
        }
        public void UpdateCart(Carts cart)
        {
            _cartRepository.Update(cart);
        }
        public void DeleteCart(Carts cart)
        {
            _cartRepository.Delete(cart);
        }
        public List<Carts> GetCarts()
        {
            throw new NotImplementedException();
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
                var user = _userService.GetUserByEmail(email);
                if (user != null)
                {
                    Carts cart = new Carts(){UserId = user.UserId, CreatedBy = user.Email, UpdatedBy = user.Email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now};
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
