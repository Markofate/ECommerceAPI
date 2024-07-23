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

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly ICartRepository _cartRepository;
        public ProductService(IProductRepository productsRepository, ICartProductRepository cartProductRepository , ICartRepository cartRepository)
        {
            _productRepository = productsRepository;
            _cartProductRepository = cartProductRepository;
            _cartRepository = cartRepository;
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
            return _productRepository.GetAll(filter);
        }

        public Products GetProductById(int id)
        {
            return _productRepository.Get(p=>p.ProductId==id);
        }
        public List<Products> GetProductsByCategoryId(int categoryId)
        {
            return _productRepository.GetAll(p=>p.CategoryId==categoryId);
        }

        public List<Products> GetProductsByUserId(int userId)
        {
            userId = 1;//login yapıldıktan sonra kalkmalı
            var cart = _cartRepository.Get(c => c.UserId == userId);
            var cartProducts = _cartProductRepository.GetAll(cp=>cp.CartId==cart.CartId);
            var products = new List<Products>();
            foreach (var product in cartProducts)
            {
                products.Add(GetProductById(product.ProductId));
            }
            return products;
        }
    }
 }
