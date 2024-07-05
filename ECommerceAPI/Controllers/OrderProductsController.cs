using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class OrderProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
