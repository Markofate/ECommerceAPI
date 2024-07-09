using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract.Repositories
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        public List<OrderProducts> GetOrderProductsByOrderId(int userId);
    }
}
