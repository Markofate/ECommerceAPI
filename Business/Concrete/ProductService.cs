using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productsRepository, ICartProductRepository cartProductRepository, ICartRepository cartRepository, IUserRepository userRepository, ILogger<ProductService> logger)
        {
            _productRepository = productsRepository;
            _cartProductRepository = cartProductRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _logger = logger;
        }
        public bool UpdateProduct(Products product)
        {
            if (product != null)
            {
                _productRepository.Update(product);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Products> GetProducts(Expression<Func<Products, bool>> filter = null)
        {
            var products = _productRepository.GetAll(filter);
            //Log.Information("Products retrieved: {@Products}", products); şeklinde loglama yapılabilir 
            return products;
        }

        public Products GetProductById(int id)
        {
            return _productRepository.Get(p => p.ProductId == id);
        }
        public List<Products> GetProductsByCategoryId(int categoryId)
        {
            return _productRepository.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Products> GetProductsByEmail(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var cart = _cartRepository.Get(c => c.UserId == user.UserId);
                var cartProducts = _cartProductRepository.GetAll(cp => cp.CartId == cart.CartId);
                var products = new List<Products>();
                foreach (var product in cartProducts)
                {
                    products.Add(GetProductById(product.ProductId));
                }
                return products;
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
