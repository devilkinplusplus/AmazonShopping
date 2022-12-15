using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Core.Helpers.Result.Abstract
{
    public interface IDataResult<TResult>:IResult
    {
        TResult Data { get; }
    }
}
