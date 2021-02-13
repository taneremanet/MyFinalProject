using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        //[LogAspect] --> AOP // loglama icin kullanilacak
        //[Validate]
        //[RemoveCache]
        //[Transaction]
        //[Performance]
        // Metot uzerinde yazarsan metot uzerinde, class uzerinde tum metotlarda calisir
        public IResult Add(Product product)
        {
            // business codes

            if (product.ProductName.Length < 2)
            {
                // Magic strings
                //return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır.");
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            //return new SuccessResult("Ürün eklendi");
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // is kodlari burada yazilacak (yetkisi var mi? gibi)

            // kural bir is sinifi baska bir sinifi new'lememeli
            //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal(); // hata, bagimlilik olur

            // bu sekilde IProductDal implemente etmis tum class'lar 
            //return _productDal.GetAll();

            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            //return _productDal.GetAll(p=>p.CategoryId == id);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            //return _productDal.Get(p => p.ProductId == productId);
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //return _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
