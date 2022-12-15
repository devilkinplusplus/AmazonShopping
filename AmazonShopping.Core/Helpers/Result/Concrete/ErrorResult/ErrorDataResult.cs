using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult
{
    public class ErrorDataResult<TResult> : DataResult<TResult>
    {
        public ErrorDataResult() : base(default , false)
        {
        }
        public ErrorDataResult(TResult data):base(data,false)
        {
        }
        public ErrorDataResult(string message):base(default,false,message)
        {
        }
        public ErrorDataResult(TResult data,string message):base(data,false,message)
        {
        }


    }
}
