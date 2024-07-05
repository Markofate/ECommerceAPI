using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
