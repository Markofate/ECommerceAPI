using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CartRepository : GenericRepository<Carts,ECommerceDbContext>, ICartRepository
    {
        private readonly IUserRepository _userRepository;
        public CartRepository(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public Carts CreateCart(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                if (user != null)
                {
                    Carts cart = new Carts() { UserId = user.UserId, CreatedBy = user.Email, UpdatedBy = user.Email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
                    Add(cart);
                    return cart;
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

            return null;
        }
    }
}
