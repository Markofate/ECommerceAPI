using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.EntityFramework.Repositories;
using Serilog;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _catogryRepository;
        public CategoryService(ICategoryRepository catogriesRepository)
        {
            _catogryRepository = catogriesRepository;
        }
        public List<Categories> GetCategories()
        {
            try
            {
                return _catogryRepository.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }

        public Categories GetByCategoryId(int id)
        {
            try
            {
                return _catogryRepository.Get(c => c.CategoryId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw e;
            }

        }

    }
}
