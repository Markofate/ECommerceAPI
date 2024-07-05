using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
