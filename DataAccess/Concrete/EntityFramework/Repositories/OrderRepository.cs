using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class OrderRepository : GenericRepository<Orders,ECommerceDbContext> , IOrderRepository
    {
        public List<OrderProducts> GetOrderProductsByOrderId(int orderId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                return context.OrderProducts.Where(op=>op.OrderId==orderId).ToList();
            }
        }
    }
}