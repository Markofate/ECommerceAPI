using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract.Repositories
{
    public interface IOrderProductRepository:IGenericRepository<OrderProducts>
    {
    }
}
