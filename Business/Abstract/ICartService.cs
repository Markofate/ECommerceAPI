using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        public List<Carts> GetCarts();
        public Carts GetCartById(int id);
        public Carts GetCartByUserId(int userId);
        public Carts CreateCart(string email);
    }
}
