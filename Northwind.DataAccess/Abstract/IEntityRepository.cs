using NorthWind.Entities.Abstract;
using NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class ,IEntity,new() // t referans tipi class IEnttiyden implemente edilecek ve newlenebilir olacak
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); // filtreleme işlemi null yaparsak boş bırakılabilir
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
