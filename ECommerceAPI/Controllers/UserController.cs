 using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class UserController : Controller
    {
        private IUserService _usersService;
        UserController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("/Users/")]
        public List<Users> GetUsers()
        {
            return _usersService.GetUsers();
        }
        [HttpGet]
        [Route("/User/{id}")]
        public Users GetUserById(int id)
        {
            return _usersService.GetUserById(id);
        }
        [HttpGet]
        [Route("/User/{id}/order")]
        public List<Orders> GetOrdersByUserId(int id)
        {
            return _usersService.GetOrdersByUserId(id);
        }
        [HttpGet]
        [Route("/User/Cart/{id}/Products")]
        public List<CartProducts> GetCartProductsByCartId(int id)
        {
            return _usersService.GetCartProductsByCartId(id);
        }
    }
}
