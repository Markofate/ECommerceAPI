using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ProductsService : IProductService
    {
        private IProductDal _productDal;
        public ProductsService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Products> GetAll()
        {
            return _productDal.GetAll();
        }

        public Products GetById(int id)
        {
            return _productDal.Get(id);
        }

    }

   
}
    


    