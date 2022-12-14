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
using X.PagedList;

namespace AmazonShopping.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IDataResult<Contact> DeleteFeedback(int id)
        {
            try
            {
                var currentData = _contactDal.Get(x => x.Id == id);
                currentData.IsDeleted = true;
                _contactDal.Update(currentData);
                return new SuccessDataResult<Contact>(currentData);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Contact>(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Contact>> GetFeedbacks(int size, int page)
        {
            try
            {
                var values = _contactDal.GetAll(x => x.IsDeleted == false).ToPagedList(page,size);
                if (values.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Contact>>(values);
                return new ErrorDataResult<IEnumerable<Contact>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Contact>>(ex.Message);
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
