using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

// Core katmanında projenin tamamında kullanilacak yapilar bulunur
// Core katmani diger katmanlari referans almaz!!
namespace Core.DataAccess
{
    // Generic Constraint - Generic Kısıtlama
    // --------------------------------------------------------------------
    // where T: class  ,referans tip, int, string vs. giremezsin demektir
    // where T: class, IEntity  ,herhangi bir class yazamasın (DividedByZeroException gibi) böylece ya IEntity olacak ya da ondan türeyen class (IEntity ile isaretledigimiz class'lar)
    // where T: class, IEntity, new() , new'lenebilir olmali yani somut class olmali (IEntity new'lenemez ondan türeyen class'lar new'lenir (Category, Customer, Product gibi))

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // filter=null sayesinde filtre vermeyebilirsin ve tüm datayı isteyebilirsin
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter); // id si olmayan sistemler icin
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
