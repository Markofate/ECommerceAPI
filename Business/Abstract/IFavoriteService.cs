﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;

namespace Business.Abstract
{
    public interface IFavoriteService
    {
        public List<Favorites> GetFavorites();
        public Favorites GetFavoriteById(int favoriteId);
        public List<Favorites> GetFavoritesByEmail(string email);
        public Favorites AddProductToFavorite(string email, int productId);
        public Favorites RemoveProductFromFavorites(string email, int productId);
    }
}
