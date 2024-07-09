using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CartRepository : GenericRepository<Carts,ECommerceDbContext>, ICartRepository
    {
        public Carts GetCartByUserId(int userId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                return context.Carts.FirstOrDefault(c => c.UserId == userId);
            }
        }
    }
}
