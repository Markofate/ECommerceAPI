﻿using Business.Abstract;
using Entities.Concrete;
using Entities.Conrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        public FavoriteController(IFavoriteService favoritiesService)
        {
            _favoriteService = favoritiesService;
        }

        [HttpGet]
        [Route("/Favorities/")]
        public List<Favorites> GetFavorites()
        {
            List<Favorites> content = _favoriteService.GetFavorites();

            return content;
        }
        [HttpGet]
        [Route("/Favorite/{id}")]
        public Favorites GetFavoriteById(int id)
        {
            Favorites content = _favoriteService.GetFavoriteById(id);
            return content;
        }
        [HttpGet]
        [Route("/FavoriteUser/{id}")]
        public List<Favorites> GetFavoritesByUserId(int userId)
        {
            List<Favorites> content = _favoriteService.GetFavoritesByUserId(userId);
            return content;
        }
    }
}