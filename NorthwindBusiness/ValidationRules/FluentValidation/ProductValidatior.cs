using FluentValidation;
using NorthwindEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p=> p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p=> p.CategoryId).NotEmpty();
            RuleFor(p=> p.QuantityPerUnit).NotEmpty();
            RuleFor(p=> p.UnitPrice).NotEmpty();
            RuleFor(p=> p.UnitsInStock).NotEmpty();

            RuleFor(p=>p.UnitPrice).GreaterThan(0);

        }
    }
}
