using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
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
        public List<string> GetUserEmails();
        public Users Register(string firstName, string lastName, string password, string rePassword,
            string email);

        public Users Authenticate(string email, string password);
    }
}