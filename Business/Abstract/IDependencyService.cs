using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDependencyService
    {
        public Users GetUserByEmail(string email);
        public Carts GetCartByUserId(int userId);
    }
}
