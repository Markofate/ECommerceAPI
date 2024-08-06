using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Entities.Concrete;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet]
        [Route("/User/Profile/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            if (email == null)
            { 
                return BadRequest(400);
            }

            return Ok(_userService.GetUserByEmail(email));

        }

        [HttpPut]
        [Route("/User/Update")]
        public IActionResult UpdateUser([FromBody]UpdateUserDTO updateUserDto)
        {
            try
            {
                if (string.IsNullOrEmpty(updateUserDto.FirstName) || string.IsNullOrEmpty(updateUserDto.LastName) || string.IsNullOrEmpty(updateUserDto.Email))
                {
                    return BadRequest("Firstname, Lastname, and Email are required");
                }
                _userService.UpdateUser(updateUserDto.FirstName, updateUserDto.LastName, updateUserDto.Email);
                return Ok("User Successfully Updated");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register([FromBody] RegisterDTO request)
        {
            try
            {
                var user = _userService.Register(request.FirstName, request.LastName, request.Password, request.RePassword, request.Email);
                return Ok(user);
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
