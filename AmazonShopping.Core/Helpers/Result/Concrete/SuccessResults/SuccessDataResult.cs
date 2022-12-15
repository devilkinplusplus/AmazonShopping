using AmazonShopping.Core.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults
{
    public class SuccessDataResult<TResult> : DataResult<TResult>
    {
        public SuccessDataResult():base(default,true)
        {
        }
        public SuccessDataResult(TResult data) : base(data, true)
        {
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
        }
        public SuccessDataResult(TResult data,string message):base(data,true,message)
        {
        }

    }
}
