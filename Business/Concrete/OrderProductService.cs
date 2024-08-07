﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Business.Concrete
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderProductService(IOrderProductRepository orderProductsRepository, ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository,
            ICartProductRepository cartProductRepository, IOrderRepository orderRepository)
        {
            _orderProductRepository = orderProductsRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _cartProductRepository = cartProductRepository;
            _orderRepository = orderRepository;

        }
        public List<OrderProducts> GetOrderProducts()
        {
            try
            {
                return _orderProductRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }
        }

        public OrderProducts GetOrderProductById(int id)
        {
            try
            {
                return _orderProductRepository.Get(op => op.OrderProductId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }
        }

        public List<OrderProducts> GetOrderProductsByOrderId(int id)
        {
            try
            {
                return _orderProductRepository.GetAll(op => op.OrderId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }
        }

        public List<OrderProducts> AddProductsToOrder(string email, string address)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c => c.UserId == user.UserId);
                var cartProducts = _cartProductRepository.GetAll(cp => cp.CartId == cart.CartId);
                var order = _orderRepository.CreateOrder(email, address);
                List<Products> productsList = [];
                decimal? totalAmount = 0;
                if (!cartProducts.IsNullOrEmpty())
                {
                    List<OrderProducts> orderProductList = [];
                    foreach (var cartProduct in cartProducts)
                    {
                        productsList.Add(_productRepository.Get(p => p.ProductId == cartProduct.ProductId));
                        OrderProducts orderProduct = new OrderProducts()
                        {
                            OrderId = order.OrderId,
                            ProductId = cartProduct.ProductId,
                            Quantity = cartProduct.Quantity,
                            CreatedAt = cartProduct.CreatedAt,
                            UpdatedAt = cartProduct.UpdatedAt,
                            CreatedBy = cartProduct.CreatedBy,
                            UpdatedBy = cartProduct.UpdatedBy
                        };
                        _orderProductRepository.Add(orderProduct);

                        orderProductList.Add(orderProduct);
                        _cartProductRepository.RemoveProductFromCart(cartProduct.ProductId, email);
                    }
                    for (int i = 0; i < productsList.Count; i++)
                    {
                        productsList[i].Stock -= cartProducts[i].Quantity;
                        productsList[i].Sales += cartProducts[i].Quantity;
                        _productRepository.Update(productsList[i]);

                        totalAmount += productsList[i].Price * cartProducts[i].Quantity;
                    }
                    order.TotalAmount = totalAmount; // Update order total amount
                    _orderRepository.Update(order);
                    
                    return orderProductList;
                }
                else
                {
                    throw new Exception("No Products At Cart");
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }
        }
    }
}

