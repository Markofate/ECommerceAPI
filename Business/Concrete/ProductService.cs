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
        public ProductService(IProductRepository productsRepository)
        {
            _productRepository = productsRepository;
        }
        public bool AddProduct(Products product)
        {
            if (product != null)
            {
                _productRepository.Add(product);
                return true;
            }
            else
            {
                return false;
            }
            
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
        public bool DeleteProduct(Products product)
        {
            if (product != null)
            {
                _productRepository.Delete(product);
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
    }
 }
