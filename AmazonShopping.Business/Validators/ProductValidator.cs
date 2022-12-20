using AmazonShopping.Business.Constants;
using AmazonShopping.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Validators
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
           RuleFor(x=>x.CategoryId).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
           RuleFor(x=>x.Name).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
        }
    }
}
