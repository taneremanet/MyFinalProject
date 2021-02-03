using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    // business katmaninin concrete'i manager
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // is kodlari burada yazilacak (yetkisi var mi? gibi)

            // kural bir is sinifi baska bir sinifi new'lememeli
            //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal(); // hata, bagimlilik olur

            // bu sekilde IProductDal implemente etmis tum class'lar 
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
