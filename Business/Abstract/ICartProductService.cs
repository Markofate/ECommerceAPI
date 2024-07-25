using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartProductService
    {
        public List<CartProducts> GetCartProducts();
        public CartProducts GetCartProductById(int id);
        public List<CartProducts> GetCartProductsByEmail(string email);
        public List<CartProducts> GetCartProductsByCartId(int cartId);
        public CartProducts AddProductToCart(int productId, int quantity, string email);
        public CartProducts RemoveProductFromCart(int productId, string email);
        public List<CartProducts> GetCartProductsByUserId(int userId);
    }
}
