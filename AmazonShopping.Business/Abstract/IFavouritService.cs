using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.Business.Abstract
{
    public interface IFavouritService
    {
        IEnumerable<Favourit> GetFavouritList(string userId);
        IDataResult<Favourit> Add(AddToFavourits favourit,string userId);
        IDataResult<Favourit> Edit(int id);
    }
}
