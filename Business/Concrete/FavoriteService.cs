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

        FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public void AddFavorite(Favorites favorite)
        {
            _favoriteRepository.Add(favorite);
        }
        public void UpdateFavorite(Favorites favorite)
        {
            _favoriteRepository.Update(favorite);
        }
        public void DeleteFavorite(Favorites favorite)
        {
            _favoriteRepository.Delete(favorite);
        }
        public List<Favorites> GetFavorites()
        {
            return _favoriteRepository.GetAll();
        }

        public Favorites GetFavoriteById(int favoriteId)
        {
            throw new NotImplementedException();
        }

        public List<Favorites> GetFavoritesByUserId(int userId)
        {
            return _favoriteRepository.GetFavoritesByUserId(userId);
        }
    }
}
