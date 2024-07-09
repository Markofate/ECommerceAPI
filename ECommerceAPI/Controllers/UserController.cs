 using Business.Abstract;
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
            List<Users> content = _usersService.GetUsers();

            return content;
        }
        [HttpGet]
        [Route("/User/{id}")]
        public Users GetUserById(int id)
        {
            Users content = _usersService.GetUserById(id);
            return content;
        }
    }
}
