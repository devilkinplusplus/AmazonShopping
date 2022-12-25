using AmazonShopping.Core.DataAcces.EntityFramework;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.DataAcces.Concrete.EntityFrameworkCore
{
    public class ReplyDal : EfRepositoryBase<Reply, AppDbContext>, IReplyDal
    {
        public IEnumerable<Reply> GetAll(Expression<Func<Reply, bool>> filter = null)
        {
            using var context = new AppDbContext();
            return context.Replies.Include(x=>x.Contact).Include(x=>x.User).Where(filter).
                ToList();
        }
    }
}
