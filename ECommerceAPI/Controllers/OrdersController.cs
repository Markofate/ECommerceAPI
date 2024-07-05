using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
