using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("/products/")]
        public string GetProducts()
        {
            return "Products Listed!";
        }
        [HttpGet]
        [Route("/products/{id}")]
        public string GetProduct(int id)
        {
            return $"Product {id} Listed!";
        }
    }
}
