using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.Conrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        [Route("/Favorites/")]
        public IActionResult GetFavorites()
        {
            var content = _favoriteService.GetFavorites();
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
        [HttpGet]
        [Route("/Favorite/{id}")]
        public IActionResult GetFavoriteById(int id)
        {
            var content = _favoriteService.GetFavoriteById(id);
            if (content != null)
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
        [HttpGet]
        [Route("/UserFavorites/{userId}")]
        public IActionResult GetFavoritesByUserId(int userId)
        {
            var content = _favoriteService.GetFavoritesByUserId(userId);
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
    }
}
