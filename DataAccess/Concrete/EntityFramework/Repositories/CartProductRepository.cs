using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CartProductRepository: GenericRepository<CartProducts,ECommerceDbContext>, ICartProductRepository
    {
    }
}
