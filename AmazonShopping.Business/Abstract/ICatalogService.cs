using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Abstract
{
    public interface ICatalogService
    {
        IDataResult<IEnumerable<Catalog>> GetAllCatalogs(int size,int page);
        IDataResult<IEnumerable<Catalog>> GetAllCatalogs();
        IResult CreateCatalog(Catalog catalog);
        IDataResult<Catalog> GetCatalogById(int id);
        IResult EditCatalog(Catalog catalog);
        IResult DeleteCatalog(Catalog catalog);
    }
}
