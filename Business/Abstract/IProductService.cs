using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        // Product ile ilgili dis dunyaya neyi servis etmek istiyorsak

        IDataResult<List<Product>> GetAll();
        //List<Product> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int id);
        //List<Product> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        //List<Product> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
        //List<ProductDetailDto> GetProductDetails();

        IDataResult<Product> GetById(int productId);
        //Product GetById(int productId);
        
        IResult Add(Product product);
        //Product Add(Product product);

        // RESTFUL --> HTTP -->
    }
}
