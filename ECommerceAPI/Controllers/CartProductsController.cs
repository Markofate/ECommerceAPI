using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CartProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
