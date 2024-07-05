using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class FavoritiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
