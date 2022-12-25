using AmazonShopping.Core.DataAcces;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.DataAcces.Abstract
{
    public interface IReplyDal : IRepositoryBase<Reply>
    {
        IEnumerable<Reply> GetAll(Expression<Func<Reply, bool>> filter = null);
    }
}
