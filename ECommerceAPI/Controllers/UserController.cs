 using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        UserController(IUserService usersService)
        {
            _userService = usersService;
        }

        [HttpGet]
        [Route("/Users/")]
        public List<Users> GetUsers()
        {
            return _userService.GetUsers();
        }
        [HttpGet]
        [Route("/User/{id}")]
        public Users GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }
    }
}
