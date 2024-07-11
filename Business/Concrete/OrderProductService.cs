using System;
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

namespace Business.Concrete
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ICartProductService _cartProductService;
        private readonly IOrderService _orderService;
        public OrderProductService(IOrderProductRepository orderProductsRepository, ICartService cartService, IProductService productService, IUserService userService,
            ICartProductService cartProductService, IOrderService orderService)
        {
            _orderProductRepository = orderProductsRepository;
            _cartService = cartService;
            _productService = productService;
            _userService = userService;
            _cartProductService = cartProductService;
            _orderService = orderService;

        }
        public void AddOrderProduct(OrderProducts orderProducts)
        {
            _orderProductRepository.Add(orderProducts);
        }
        public void UpdateOrderProduct(OrderProducts orderProducts)
        {
            _orderProductRepository.Update(orderProducts);
        }
        public void DeleteOrderProduct(OrderProducts orderProducts)
        {
            _orderProductRepository.Delete(orderProducts);
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

        public List<OrderProducts> AddProductsToOrder(string email)
        {
            try
            {

                var user = _userService.GetUserByEmail(email);
                var cart = _cartService.GetCartByUserId(user.UserId);
                var cartProducts = _cartProductService.GetCartProductsByCartId(cart.CartId);
                var order = _orderService.CreateOrder(email);
                List<Products> productsList = null;
                if (!cartProducts.IsNullOrEmpty())
                {
                    List<OrderProducts> orderProductList = null;
                    foreach (var cartProduct in cartProducts)
                    {
                        productsList.Add(_productService.GetProductById(cartProduct.ProductId));
                        OrderProducts orderProduct = new OrderProducts()
                        { OrderId = order.OrderId,
                            ProductId = cartProduct.ProductId, Quantity = cartProduct.Quantity, CreatedAt = cartProduct.CreatedAt, UpdatedAt = cartProduct.UpdatedAt,
                            CreatedBy = cartProduct.CreatedBy, UpdatedBy = cartProduct.UpdatedBy 
                        };

                        _cartProductService.RemoveProductFromCart(cartProduct.ProductId, email);
                        foreach (var product in productsList)
                        {
                            product.Stock -= cartProduct.Quantity;
                            _productService.UpdateProduct(product);
                            
                        }
                        orderProductList.Add(orderProduct);
                    }

                    return orderProductList;
                }
                else
                {
                    throw new Exception("Something Went Wrong");
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

