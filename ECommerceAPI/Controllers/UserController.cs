 using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService usersService)
        {
            _userService = usersService;
        }

        [HttpGet]
        [Route("/Users/")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpGet]
        [Route("/User/{id}")]
        public IActionResult GetUserById(int id)
        {
            if (id != null)
            {
                return Ok(_userService.GetUserById(id));
            }
            else
            {
                return BadRequest(400);
            }
            
        }

        [HttpPost]
        [Route("/Register/{firstName}/{lastName}/{password}/{rePassword}/{email}")]
        public IActionResult Register(string firstName, string lastName, string password, string rePassword, string email)
        {
            if (true)
            {
                return Ok(_userService.Register(firstName, lastName, password, rePassword, email));
            }
        }
    }
}
