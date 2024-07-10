using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public List<Products> GetProducts();
        public Products GetProductById(int id);
        public Products GetProductByCategoryId(params int[] categoryId);
    }
}
