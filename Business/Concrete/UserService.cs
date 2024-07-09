using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(Users user)
        {
            _userRepository.Add(user);
        }
        public void UpdateUser(Users user)
        {
            _userRepository.Update(user);
        }
        public void DeleteUser(Users user)
        {
            _userRepository.Delete(user);
        }
        public List<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetOrdersByUserId(int id)
        {
            return _userRepository.GetOrderByUserId(id);
        }
        public List<CartProducts> GetCartProductsByCartId(int cartId)
        {
            return _userRepository.GetCartProductsByCartId(cartId);
        }
    }
}
