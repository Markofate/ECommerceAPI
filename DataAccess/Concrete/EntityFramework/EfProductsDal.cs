using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductsDal : IProductDal
    {
        public List<Products> GetAll()
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                return context.Products.ToList();
            }

        }

        public Products Get(int id)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }

        public void Add(Products products)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                context.Products.Add(products);
                context.SaveChanges();
            }
        }

        public void Update(Products products)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                context.Products.Add(products);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {

        }

    }
}
