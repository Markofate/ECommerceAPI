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

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
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
            throw new NotImplementedException();
        }

        public Carts GetCartByUserId(int userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }
    }
}
