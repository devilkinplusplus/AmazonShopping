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
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage(Messages.OutOfRange);
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(Messages.CannotBeNull);
            RuleFor(x=>x.Email).EmailAddress().WithMessage(Messages.InvalidMail);
            RuleFor(x=>x.Message).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
            RuleFor(x=>x.Message).MaximumLength(255).WithMessage(Messages.OutOfRange);
        }
    }
}
