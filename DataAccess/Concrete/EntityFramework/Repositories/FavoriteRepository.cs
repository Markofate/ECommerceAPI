using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Conrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorites, ECommerceDbContext>, IFavoriteRepository
    {
    }
}