using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CartProductRepository: GenericRepository<CartProducts,ECommerceDbContext>, ICartProductRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        public CartProductRepository(IUserRepository userRepository, ICartRepository cartRepository)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
        }
        public CartProducts RemoveProductFromCart(int productId, string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c => c.UserId == user.UserId);
                var cartProduct = Get(cp => cp.CartId == cart.CartId && cp.ProductId == productId);

                if (cart != null && cartProduct != null)
                {
                    Delete(cartProduct);
                    return cartProduct;
                }
                else
                {
                    throw new Exception("Cart Or Product Not Found");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return null;
        }
    }
}
