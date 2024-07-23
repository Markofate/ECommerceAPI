using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public bool UpdateProduct(Products product);
        public List<Products> GetProducts(Expression<Func<Products, bool>> filter = null);
        public Products GetProductById(int id);
        public List<Products> GetProductsByCategoryId(int categoryId);
        public List<Products> GetProductsByUserId(int cartId);
    }
}
