using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Business.Concrete
{
    public class CartProductService: ICartProductService
    {
        private readonly ICartProductRepository _cartProductRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public CartProductService(ICartProductRepository cartProductRepository, ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _cartProductRepository = cartProductRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            
        }
        public List<CartProducts> GetCartProducts()
        {
            return _cartProductRepository.GetAll();
        }
        
        public CartProducts GetCartProductById(int id)
        {
            return _cartProductRepository.Get(cp => cp.CartProductId == id);
        }

        public List<CartProducts> GetCartProductsByCartId(int cartId)
        {
            return _cartProductRepository.GetAll(cp => cp.CartId == cartId);
        }

        public CartProducts GetCartProductByProductAndCartId(int cartId, int productId)
        {
            return _cartProductRepository.Get(cp => cp.CartId == cartId && cp.ProductId == productId);
        }

        public CartProducts AddProductToCart(int productId, int quantity, string email)
        {
            try
            {
                var user = _userRepository.Get(u=>u.Email==email);
                var cart = _cartRepository.Get(c=>c.UserId==user.UserId);
                var product = _productRepository.Get(p=>p.ProductId == productId);
                if (cart != null)
                {

                    CartProducts cartProduct = new CartProducts()
                    {
                        CartId = cart.CartId, ProductId = productId, Quantity = quantity, CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = cart.CreatedBy, UpdatedBy = cart.UpdatedBy
                    };
                    _cartProductRepository.Add(cartProduct);

                    cart.TotalAmount += quantity * product.Price;

                    return cartProduct;
                }
                else
                {
                    throw new Exception("Cart Not Found");
                }
            }
            catch(Exception exception)
            { 
                Console.WriteLine(exception);
            }

            return null;
        }

        public CartProducts RemoveProductFromCart(int productId, string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c => c.UserId == user.UserId);
                var cartProduct = GetCartProductByProductAndCartId(cart.CartId, productId);

                if (cart != null && cartProduct != null)
                {
                    _cartProductRepository.Delete(cartProduct);
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
