 using Business.Abstract;
using Business.Concrete;
using ECommerceAPI.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
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
            if (id == null)
            {
                return BadRequest(400);
            }
            else
            {
                return Ok(_userService.GetUserById(id));
            }

        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register([FromBody]RegisterViewModel registerViewModel)
        {
            if (true)
            {
                return Ok(_userService.Register(registerViewModel.FirstName, registerViewModel.LastName, registerViewModel.Password
                    , registerViewModel.RePassword, registerViewModel.Email));
            }
        }
    }
}
