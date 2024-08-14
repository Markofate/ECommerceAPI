using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        public UserService(IUserRepository userRepository, ICartRepository cartRepository)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
        }

        public List<Users> GetUsers()
        {
            try
            {
                return _userRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Users GetUserById(int id)
        {
            try
            {
                return _userRepository.Get(ui => ui.UserId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }
        public Users GetUserByEmail(string email)
        {
            try
            {
                return _userRepository.Get(u => u.Email == email);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Users UpdateUser(string firstname, string lastname, string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                if (user != null)
                {
                    user.FirstName = firstname;
                    user.LastName = lastname;
                    user.UpdatedAt = DateTime.Now;
                    user.UpdatedBy = firstname + lastname;
                    _userRepository.Update(user);
                    return user;
                }
                throw new Exception("Couldn't Find User");

            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }
        }

        public List<string> GetUserEmails()
        {
            try
            {
                return _userRepository.GetAll().Select(u => u.Email).ToList();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Users Register(string firstName, string lastName, string password, string rePassword, string email)
        {
            try
            {
                if (firstName.IsNullOrEmpty() || lastName.IsNullOrEmpty() || password.IsNullOrEmpty() || rePassword.IsNullOrEmpty() || email.IsNullOrEmpty())
                {
                    throw new Exception("Something Is Blank");
                }
                if (GetUserEmails().Contains(email))
                {
                    throw new Exception("Email is Already Used");
                }
                if (password != rePassword)
                {
                    throw new Exception("Passwords Do Not Match");
                }
                if (password == rePassword)
                {
                    Users user = new Users()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Password = password,
                        CreatedBy = email,
                        UpdatedBy = email,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _userRepository.Add(user);
                    _cartRepository.CreateCart(email);
                    return user;
                }


            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }

            return null;
        }

        public Users Authenticate(string email, string password)
        {
            try
            {
                var user = GetUserByEmail(email);
                if (user != null && user.Password == password)
                {
                    return user;
                }

                throw new Exception(message:"Incorrect Email or Password");
            }

            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }
        }
    }

}
