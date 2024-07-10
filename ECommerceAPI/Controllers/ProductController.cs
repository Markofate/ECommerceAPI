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
        private readonly IProductService _productService;
        public ProductController(IProductService productsService)
        {
            _productService = productsService;
        }
        
        [HttpGet]
        [Route("/products/")]
        public List<Products> GetProducts()
        {
            var content = _productService.GetProducts();

            return content;
        }
        [HttpGet]
        [Route("/product/{id}")]
        public Products GetProductById(int id)
        {
            Products content = _productService.GetProductById(id);
            return content ;
        }
    }
}
