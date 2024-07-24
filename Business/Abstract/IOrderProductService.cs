using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderProductService 
    {
        public List<OrderProducts> GetOrderProducts();
        public OrderProducts GetOrderProductById(int id);
        public List<OrderProducts> GetOrderProductsByOrderId(int id);
        public List<OrderProducts> AddProductsToOrder(string email, string address);
    }
}
