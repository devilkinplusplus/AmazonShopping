using AmazonShopping.Core.DataAcces;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.DataAcces.Abstract
{
    public interface IFavouritDal:IRepositoryBase<Favourit>
    {
        IEnumerable<Favourit> GetAll(string userId);
    }
}
