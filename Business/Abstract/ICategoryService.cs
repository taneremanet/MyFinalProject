using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        // Kategori ile ilgili dis dunyaya neyi servis etmek istiyorsak

        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
