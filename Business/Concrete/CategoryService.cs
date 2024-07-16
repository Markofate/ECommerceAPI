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
        private readonly ICategoryRepository _catogryRepository;
        public CategoryService(ICategoryRepository catogriesRepository)
        {
            _catogryRepository = catogriesRepository;
        }
        public bool AddCategory(Categories category)
        {
            if (category != null)
            {
                _catogryRepository.Add(category);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool UpdateCategory(Categories category)
        {
            if (category != null)
            {
                _catogryRepository.Update(category);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool DeleteCategory(Categories category)
        {
            if (category != null)
            {
                _catogryRepository.Delete(category);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<Categories> GetCategories()
        {
            return _catogryRepository.GetAll();
        }

        public Categories GetByCategoryId(int id)
        {
            return _catogryRepository.Get(c => c.CategoryId == id);
        }

    }
}
