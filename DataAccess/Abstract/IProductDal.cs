using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        public List<Products> GetAll();
        public Products Get(int id);
        public void Add(Products products);
        public void Update(Products products);
        public void Delete(int id);
    }
}
