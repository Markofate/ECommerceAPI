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
        public List<CartProducts> GetCartProductsByCartId(int cartId);
        public void AddProductToCart(int productId, int cartId, int quantity);
    }
}
