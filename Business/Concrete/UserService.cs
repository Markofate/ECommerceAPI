﻿using System;
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

        private ICartService _cartService;
        public UserService(IUserRepository userRepository, ICartService cartService)
        {
            _userRepository = userRepository;
                _cartService = cartService;
        }
        
        public List<Users> GetUsers()
        {
           return _userRepository.GetAll();
        }

        public Users GetUserById(int id)
        {
            return _userRepository.Get(ui=>ui.UserId==id);
        }
        public Users GetUserByEmail(string email)
        {
            return _userRepository.Get(u=>u.Email==email);
        }

        public Users Register(string firstName, string lastName, string password, string rePassword, string email)
        {
            try
            {
                if (firstName == null || lastName == null || password == null || rePassword == null || email == null)
                {
                    throw new Exception("Something Is Blank");
                }
                if (email == GetUserByEmail(email).Email)
                {
                    throw new Exception("Email is Already Used");
                }
                if (password == rePassword)
                {
                    Users user = new Users()
                    {
                        FirstName = firstName, LastName = lastName, Email = email, Password = password,
                        CreatedBy = email, UpdatedBy = email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
                    };
                    _userRepository.Add(user);
                    _cartService.CreateCart(email);
                    return user;
                }
                else
                {
                    throw new Exception("Passwords Do Not Match");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public bool Login(string email,string password)
        {
            try
            {
                var user = GetUserByEmail(email);
                if (user != null)
                {
                    if (user.Password==password)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Password Or Email Wrong");
                    }
                }
                else
                {
                    throw new Exception("Couldn't Find User");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public bool Logout(string email)
        {

            try
            {
                var user = GetUserByEmail(email);
                //logout kodu

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }
    }
}
