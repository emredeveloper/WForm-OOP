using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NhHibernate
{
    public class NhProductDal : EfEntityRepositoryBase<Product,NorthwindContext>
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

       

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{CategoryId=1, ProductName="Laptop",
                    QuantityPerUnit = "1 in a box",
                    UnitPrice =3000,UnitsInStock= 11},


                new Product{CategoryId=2, ProductName="Araba",
                    QuantityPerUnit = "1 in a Garaj",
                    UnitPrice =300000,UnitsInStock= 1}

            };


            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
