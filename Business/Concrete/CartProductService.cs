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
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public CartProductService(ICartProductRepository cartProductRepository, ICartService cartService, IProductService productService, IUserService userService)
        {
            _cartProductRepository = cartProductRepository;
            _cartService= cartService;
            _productService = productService;
            _userService = userService;
            
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

        public CartProducts GetCartProductByProductId(int cartId, int productId)
        {
            return _cartProductRepository.Get(cp => cp.CartId == cartId && cp.ProductId == productId);
        }

        public CartProducts AddProductToCart(int productId, int quantity, string email)
        {
            try
            {
                var user = _userService.GetUserByEmail(email);
                var cart = _cartService.GetCartByUserId(user.UserId);
                var product = _productService.GetProductById(productId);
                if (cart != null)
                {

                    CartProducts cartProduct = new CartProducts()
                    {
                        CartId = cart.CartId, ProductId = productId, Quantity = quantity, CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = cart.CreatedBy, UpdatedBy = cart.UpdatedBy
                    };
                    AddCartProduct(cartProduct);

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
                var user = _userService.GetUserByEmail(email);
                var cart = _cartService.GetCartByUserId(user.UserId);
                var cartProduct = GetCartProductByProductId(cart.CartId, productId);

                if (cart != null && cartProduct != null)
                {
                    DeleteCartProduct(cartProduct);
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
