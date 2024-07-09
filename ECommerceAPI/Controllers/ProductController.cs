using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productsService;
        public ProductController(IProductService productsService)
        {
            _productsService = productsService;
        }
        
        [HttpGet]
        [Route("/products/")]
        public List<Products> GetProducts()
        {
            var content = _productsService.GetProducts();

            return content;
        }
        [HttpGet]
        [Route("/product/{id}")]
        public Products GetProductById(int id)
        {
            Products content = _productsService.GetProductById(id);
            return content ;
        }
    }
}
