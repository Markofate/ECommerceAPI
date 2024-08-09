using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Serilog;

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
            try
            {
                return _favoriteRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Favorites GetFavoriteById(int favoriteId)
        {
            try
            {
                return _favoriteRepository.Get(f => f.FavoriteId == favoriteId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public List<Favorites> GetFavoritesByEmail(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email == email);
                return _favoriteRepository.GetAll(f => f.UserId == user.UserId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Favorites GetFavoriteByProductId(int productId)
        {
            try
            {
                return _favoriteRepository.Get(f => f.ProductId == productId);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

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
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }
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
                    Log.Information("Favorite {@favorite} Removed By: {@email}", favorite, email);
                    return favorite;
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }
        }
    }
}
