using AmazonShopping.Business.Constants;
using AmazonShopping.Core.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.Firstname).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
            RuleFor(x=>x.Firstname).MinimumLength(2).MaximumLength(25).WithMessage(Messages.OutOfRange);
        
            RuleFor(x=>x.Lastname).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
            RuleFor(x => x.Lastname).MinimumLength(2).MaximumLength(25).WithMessage(Messages.OutOfRange);

            RuleFor(x=>x.Email).NotNull().NotEmpty().WithMessage(Messages.CannotBeNull);
            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.InvalidMail);

        }
    }
}
