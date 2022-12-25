using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Abstract
{
    public interface IContactService
    {
        IDataResult<IEnumerable<Contact>> GetFeedbacks();
        IDataResult<Contact> SendFeedback(Contact contact);
        IDataResult<Contact> DeleteFeedback(int id);
    }
}
