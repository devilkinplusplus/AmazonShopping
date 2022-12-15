using AmazonShopping.Core.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Core.Helpers.Result.Concrete
{
    public class DataResult<TResult> : Result, IDataResult<TResult>
    {
        public DataResult(TResult data,bool success) : base(success)
        {
            Data=data;
        }
        public DataResult(TResult data ,bool success,string message):base(success,message)
        {
            Data=data;
        }

        public TResult Data { get; }
    }
}
