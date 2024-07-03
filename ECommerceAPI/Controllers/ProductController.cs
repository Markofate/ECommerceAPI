using Entities.Conrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        Products _product = new Products()
            {
                ProductId = 1, Product = "ToyCar", Description = "A toy car", Price = 500, Currency = "TRY",
                Stock = 10, CreatedBy = "Kemal", UpdatedBy = "Kemal", DeletedBy = ""
            };
        [HttpGet]
        [Route("/products/")]
        public Products GetProducts()
        {
            
            return _product;
        }
        [HttpGet]
        [Route("/products/{id}")]
        public string GetProduct(int id)
        {
            return $"Product {id} Listed!";
        }
    }
}
