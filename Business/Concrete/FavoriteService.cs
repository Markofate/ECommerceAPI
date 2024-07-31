using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Entities.Conrete;

namespace Business.Concrete
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IUserRepository _userRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository, IUserRepository userRepository)
        {
            _favoriteRepository = favoriteRepository;
            _userRepository = userRepository;
        }
        public List<Favorites> GetFavorites()
        {
            return _favoriteRepository.GetAll();
        }

        public Favorites GetFavoriteById(int favoriteId)
        {
            return _favoriteRepository.Get(f => f.FavoriteId == favoriteId);
        }

        public List<Favorites> GetFavoritesByEmail(string email)
        {
            var user = _userRepository.Get(u => u.Email == email);
            return _favoriteRepository.GetAll(f=>f.UserId==user.UserId);
        }

        public Favorites GetFavoriteByProductId(int productId)
        {
            return _favoriteRepository.Get(f => f.ProductId == productId);
        }

        public Favorites AddProductToFavorite(string email, int productId)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                if (user != null)
                {
                    Favorites favorite = new Favorites()
                    {
                    UserId = user.UserId,
                    ProductId = productId, 
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = user.Email,
                    UpdatedBy = user.Email,
                    };
                    _favoriteRepository.Add(favorite);
                    return favorite;
                }

                throw new Exception("Couldn't Find User");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public Favorites RemoveProductFromFavorites(string email, int productId)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                var favorite = GetFavoriteByProductId(productId);
                if (user != null && favorite != null)
                {
                    _favoriteRepository.Delete(favorite);
                    return favorite;
                }
                else
                {
                    throw new Exception("Something went wrong");
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
