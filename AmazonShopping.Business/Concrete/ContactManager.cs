using AmazonShopping.Business.Abstract;
using AmazonShopping.Business.Constants;
using AmazonShopping.Business.Validators;
using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult;
using AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IEnumerable<Contact> GetFeedbacks()
        {
            try
            {
                var values = _contactDal.GetAll(x => x.IsDeleted == false);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IDataResult<Contact> SendFeedback(Contact contact)
        {
            try
            {
                ContactValidator validationRules = new ContactValidator();
                ValidationResult result = validationRules.Validate(contact);
                if (result.IsValid)
                {
                    contact.IsDeleted = false;
                    contact.Date = DateTime.Now;
                    _contactDal.Add(contact);
                    return new SuccessDataResult<Contact>(contact);
                }
                return new ErrorDataResult<Contact>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
