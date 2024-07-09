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
    public class CartProductService: ICartProductService
    {
        private ICartProductRepository _cartProductRepository;

        public CartProductService(ICartProductRepository cartProductRepository)
        {
            _cartProductRepository = cartProductRepository;
        }
        public void AddCartProduct(CartProducts product)
        {
            _cartProductRepository.Add(product);
        }
        public void UpdateCartProduct(CartProducts product)
        {
            _cartProductRepository.Update(product);
        }
        public void DeleteCartProduct(CartProducts product)
        {
            _cartProductRepository.Delete(product);
        }
        public List<CartProducts> GetCartProducts()
        {
            throw new NotImplementedException();
        }

        public CartProducts GetCartProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
