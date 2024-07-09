using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserRepository : GenericRepository<Users,ECommerceDbContext> , IUserRepository
    {
        public List<Orders> GetOrderByUserId(int id)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                return context.Orders.Where(o => o.UserId == id).ToList();
            }
        }
        public List<CartProducts> GetCartProductsByCartId(int cartId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                return context.CartProducts.Where(cp => cp.CartId == cartId).ToList();
            }
        }
    }
}
