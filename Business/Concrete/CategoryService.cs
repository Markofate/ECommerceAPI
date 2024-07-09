using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _catogriesRepository;
        public CategoryService(ICategoryRepository catogriesRepository)
        {
            _catogriesRepository = catogriesRepository;
        }
        public void AddCategory(Categories category)
        {
            _catogriesRepository.Add(category);
        }
        public void UpdateCategory(Categories category)
        {
            _catogriesRepository.Update(category);
        }
        public void DeleteCategory(Categories category)
        {
            _catogriesRepository.Delete(category);
        }
        public List<Categories> GetCategories()
        {
            return _catogriesRepository.GetAll();
        }

        public Categories GetByCategoryId(int id)
        {
            return _catogriesRepository.Get(c => c.CategoryId == id);
        }

    }
}
