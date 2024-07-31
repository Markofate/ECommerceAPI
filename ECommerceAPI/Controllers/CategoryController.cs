using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public IActionResult GetCategories()
        {
            var content = _categoryService.GetCategories();
            if (!content.IsNullOrEmpty())
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
        [HttpGet]
        [Route("/category/{id}")]
        public IActionResult GetByCategoryId(int id)
        {
            var content = _categoryService.GetByCategoryId(id);
            if (content != null)
            {
                return Ok(content);
            }
            else
            {
                return BadRequest(400);
            }
        }
    }
}
