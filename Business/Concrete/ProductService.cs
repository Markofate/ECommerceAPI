﻿ using System;
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
        public ProductService(IProductRepository productsRepository)
        {
            _productRepository = productsRepository;
        }
        public void AddProduct(Products product)
        {
            _productRepository.Add(product);
        }
        public void UpdateProduct(Products product)
        {
            _productRepository.Update(product);
        }
        public void DeleteProduct(Products product)
        {
            _productRepository.Delete(product);
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
    }
 }
