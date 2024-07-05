using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceAPI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productsService = new ProductsService(new EfProductsDal());
        [HttpGet]
        [Route("/products/")]
        public List<Products> GetProducts()
        {
            List<Products> content = _productsService.GetAll();

            return content;
        }
        [HttpGet]
        [Route("/products/{id}")]
        public Products GetProduct(int id)
        {
            Products content = _productsService.GetById(id);
            return content ;
        }
    }
}
