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
    public class ReplyValidator:AbstractValidator<Reply>
    {
        public ReplyValidator()
        {
            RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
            RuleFor(x => x.Content).MaximumLength(300).WithMessage(Messages.OutOfRange);
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);
            RuleFor(x => x.ContactId).NotEmpty().NotNull().WithMessage(Messages.CannotBeNull);

        }
    }
}
