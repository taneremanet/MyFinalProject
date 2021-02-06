using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // NuGet - EntityFramework - entityframeworkcore.sql - 3.1.11
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        // Urune ait ozel islemleri buraya getirecegiz
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                // Urunler ile Kategorileri join ediyoruz
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto 
                             {
                                 ProductId = p.ProductId, 
                                 ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, 
                                 UnitsInStock = p.UnitsInStock 
                             };
                return result.ToList();
            }
        }
    }
}
