using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoriesService)
        {
            _categoryService = categoriesService;
        }
        [HttpGet]
        [Route("/categories/")]
        public List<Categories> GetCategories()
        {
            List<Categories> content = _categoryService.GetCategories();

            return content;
        }
        [HttpGet]
        [Route("/category/{id}")]
        public Categories GetByCategoryId(int id)
        {
            Categories content = _categoryService.GetByCategoryId(id);
            return content;
        }
    }
}
