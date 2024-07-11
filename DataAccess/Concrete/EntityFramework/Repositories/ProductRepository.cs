using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class ProductRepository : GenericRepository<Products, ECommerceDbContext>, IProductRepository
    {
    }
}
