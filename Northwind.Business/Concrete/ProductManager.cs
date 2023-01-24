using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules;

using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Business.ValidationTool;

namespace Northwind.Business.Concrete.EntityFramework
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryDal _categorydal;

        

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            Validationtool.Validate(new ProductValidator(),product); // oluşturduğumuz toolu burada kullandık/ çağırdık
                
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {

                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public List<Product> GetAll()
        {
            // Business Code
            return _productDal.GetAll();

        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productname)
        {
           return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(productname.ToLower()));
        }

        public void Update(Product product)
        {
            Validationtool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
