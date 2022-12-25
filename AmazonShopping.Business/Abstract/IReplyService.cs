using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ContactDTO;

namespace AmazonShopping.Business.Abstract
{
    public interface IReplyService
    {
        IDataResult<Reply> ReplyFeedback(ReplyDTO reply,string userId);
        IDataResult<IEnumerable<Reply>> GetReplies(string userId);
        IDataResult<Reply> DeleteReply(int id);
    }
}
