using FluentValidation;
using Northwind.Business.ValidationRules;
using NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationTool
{
    public static class Validationtool
    {
        public static void Validate(IValidator validator, object entity)
        {

            var result = validator.Validate((IValidationContext)entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
