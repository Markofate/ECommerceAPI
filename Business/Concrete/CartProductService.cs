using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Business.Concrete
{
    public class CartProductService : ICartProductService
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
            try
            {
                return _cartProductRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public CartProducts GetCartProductById(int id)
        {
            try
            {
                return _cartProductRepository.Get(cp => cp.CartProductId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public List<CartProducts> GetCartProductsByCartId(int cartId)
        {
            try
            {
                return _cartProductRepository.GetAll(cp => cp.CartId == cartId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public List<CartProducts> GetCartProductsByEmail(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c => c.UserId == user.UserId);

                return _cartProductRepository.GetAll(cp => cp.CartId == cart.CartId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public CartProducts GetCartProductByProductAndCartId(int cartId, int productId)
        {
            try
            {
                return _cartProductRepository.Get(cp => cp.CartId == cartId && cp.ProductId == productId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }
           
        }

        public CartProducts AddProductToCart(int productId, int quantity, string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c => c.UserId == user.UserId);
                var product = _productRepository.Get(p => p.ProductId == productId);
                var cartProducts = GetCartProductsByCartId(cart.CartId);
                bool isInCart = false;


                if (cart != null)
                {
                    CartProducts cartProduct = new CartProducts()
                    {
                        CartId = cart.CartId,
                        ProductId = productId,
                        Quantity = quantity,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = cart.CreatedBy,
                        UpdatedBy = cart.UpdatedBy
                    };
                    if (cartProducts.Count == 0)
                    {
                        _cartProductRepository.Add(cartProduct);

                        cart.TotalAmount += quantity * product.Price;

                        return cartProduct;
                    }
                    foreach (var cp in cartProducts)
                    {
                        if (cp.ProductId == productId)
                        {
                            isInCart = true;
                        }
                        if (isInCart)
                        {
                            var newQuantity = cp.Quantity + quantity;
                            if (newQuantity <= product.Stock)
                            {
                                cp.Quantity = newQuantity;
                                _cartProductRepository.Update(cp);
                                cart.TotalAmount += quantity * product.Price;
                                return cp;
                            }
                            throw new Exception("No Available Stock");

                        }
                    }
                    if (!isInCart)
                    {
                        _cartProductRepository.Add(cartProduct);

                        cart.TotalAmount += quantity * product.Price;

                        return cartProduct;
                    }
                }
                else
                {
                    throw new Exception("Cart Not Found");
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;

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
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }
        }

        public List<CartProducts> GetCartProductsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
