using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;

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
        public IActionResult Register([FromBody] RegisterDTO request)
        {
            try
            {
                var user = _userService.Register(request.FirstName, request.LastName, request.Password, request.RePassword, request.Email);
                if (user != null)
                {
                    return Ok(user);
                }

                return null;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("/Login")]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            try
            {
                var user = _userService.Authenticate(request.Email, request.Password);
                return Ok(user); // HTTP 200 OK
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new { message = e.Message }); // HTTP 401 Unauthorized
            }
            catch (Exception e)
            {
                // Log the exception if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred" });
            }
        }
    }
}
