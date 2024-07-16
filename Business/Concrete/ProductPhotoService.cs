using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IProductPhotoRepository _productPhotoRepository;

        public ProductPhotoService(IProductPhotoRepository productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }

        public bool AddProductPhoto(ProductPhotos photo)
        {
            if (photo != null)
            {
                _productPhotoRepository.Add(photo);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateProductPhoto(ProductPhotos photo)
        {
            if (photo != null)
            {
                _productPhotoRepository.Update(photo);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteProductPhoto(ProductPhotos photo)
        {
            if (photo != null)
            {
                _productPhotoRepository.Delete(photo);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
