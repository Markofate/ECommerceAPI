using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public List<Users> GetUsers();
        public Users GetUserById(int id);
        public Users GetUserByEmail(string email);
    }
}