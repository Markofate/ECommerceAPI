using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Conrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Favorites> Favorities { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Users> Users { get; set; }

        public ECommerceDbContext()
        {
        }
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=kemal-kunt;Database=ECommerce;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

    }

}
