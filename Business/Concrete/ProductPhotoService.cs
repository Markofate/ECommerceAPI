using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using Serilog;

namespace Business.Concrete
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IProductPhotoRepository _productPhotoRepository;

        public ProductPhotoService(IProductPhotoRepository productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }
        public List<ProductPhotos> GetProductPhotosByProductId(int id)
        {
            try
            {
                return _productPhotoRepository.GetAll(pp => pp.ProductId == id);
            }
            catch (Exception e)
            {
                Log.Error("Error Occured: {@e}", e);
                throw;
            }

        }
    }
}
