using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoriesService;
        public CategoryController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet]
        [Route("/categories/")]
        public List<Categories> GetCategories()
        {
            List<Categories> content = _categoriesService.GetCategories();

            return content;
        }
        [HttpGet]
        [Route("/category/{id}")]
        public Categories GetByCategoryId(int id)
        {
            Categories content = _categoriesService.GetByCategoryId(id);
            return content;
        }
    }
}
