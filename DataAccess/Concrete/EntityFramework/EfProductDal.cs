using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // NuGet - EntityFramework - entityframeworkcore.sql - 3.1.11
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext> ,IProductDal
    {
        // Urune ait ozel islemleri buraya getirecegiz
    }
}
