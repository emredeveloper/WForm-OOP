using FluentValidation;
using NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product> // product için kurallar yazacağız
    {
        // fluent validation
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz"); // product name boş olmayacak
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();

            RuleFor(p=> p.UnitPrice).GreaterThan(0); // 0'dan büyük olacak unitprice
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün A ile başlamalı"); // must ile içine func ismi girdik onu tanımladık
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); // bu func içindeki değer mustın içine ulaşacak ve kuralımız
            // sağlanmış olacak
        }
    }
}
