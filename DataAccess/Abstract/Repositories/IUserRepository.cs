using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract.Repositories
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        public List<Orders> GetOrderByUserId(int id);
        public List<CartProducts> GetCartProductsByCartId(int cartId);
    }
}
