using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        public List<Orders> GetOrders();
        public Orders GetOrderById(int id);
        public List<OrderProducts> GetByOrderId(int id);
    }
}

