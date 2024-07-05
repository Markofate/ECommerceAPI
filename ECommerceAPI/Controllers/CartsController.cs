using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
