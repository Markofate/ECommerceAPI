using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Entities.Conrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            return _orderProductRepository.GetAll();
        }

        public OrderProducts GetOrderProductById(int id)
        {
            return _orderProductRepository.Get(op=>op.OrderProductId==id);
        }

        public List<OrderProducts> GetOrderProductsByOrderId(int id)
        {
            return _orderProductRepository.GetAll(op=>op.OrderId==id);
        }

        public List<OrderProducts> AddProductsToOrder(string email, string address)
        {
            try
            {

                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c=>c.UserId==user.UserId);
                var cartProducts = _cartProductRepository.GetAll(cp=>cp.CartId==cart.CartId);
                var order = _orderRepository.CreateOrder(email,address);
                List<Products> productsList = [];
                if (!cartProducts.IsNullOrEmpty())
                {
                    List<OrderProducts> orderProductList = [];
                    foreach (var cartProduct in cartProducts)
                    {
                        productsList.Add(_productRepository.Get(p=>p.ProductId == cartProduct.ProductId));
                        OrderProducts orderProduct = new OrderProducts()
                        { OrderId = order.OrderId,
                            ProductId = cartProduct.ProductId, Quantity = cartProduct.Quantity, CreatedAt = cartProduct.CreatedAt, UpdatedAt = cartProduct.UpdatedAt,
                            CreatedBy = cartProduct.CreatedBy, UpdatedBy = cartProduct.UpdatedBy
                        };
                        _orderProductRepository.Add(orderProduct);

                        _cartProductRepository.RemoveProductFromCart(cartProduct.ProductId, email);
                        foreach (var product in productsList)
                        {
                            product.Stock -= cartProduct.Quantity;
                            product.Sales += cartProduct.Quantity;
                            _productRepository.Update(product); 
                            
                        }
                        orderProductList.Add(orderProduct);
                    }

                    return orderProductList;
                }
                else
                {
                    throw new Exception("No Products At Cart");
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

