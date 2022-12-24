using AmazonShopping.Business.Abstract;
using AmazonShopping.Business.Constants;
using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult;
using AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.DataAcces.Concrete.EntityFrameworkCore;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Concrete
{
    public class CatalogManager : ICatalogService
    {
        private readonly ICatalogDal _catalogDal;

        public CatalogManager(ICatalogDal catalogDal)
        {
            _catalogDal = catalogDal;
        }

        public IResult CreateCatalog(Catalog catalog)
        {
            try
            {
                _catalogDal.Add(catalog);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult DeleteCatalog(Catalog catalog)
        {
            try
            {
                var data = _catalogDal.Get(x => x.Id == catalog.Id);
                data.IsDeleted = true;
                _catalogDal.Update(data);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult EditCatalog(Catalog catalog)
        {
            try
            {
                var data = _catalogDal.Get(x => x.Id == catalog.Id);
                data.Name = catalog.Name;
                _catalogDal.Update(data);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Catalog>> GetAllCatalogs()
        {
            try
            {
                var values = _catalogDal.GetAll(x => x.IsDeleted == false);
                if (values.Count() != 0)
                {
                    return new SuccessDataResult<IEnumerable<Catalog>>(values);
                }
                return new ErrorDataResult<IEnumerable<Catalog>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IDataResult<Catalog> GetCatalogById(int id)
        {
            try
            {
                var data = _catalogDal.Get(x => x.Id == id);
                if (data != null)
                {
                    return new SuccessDataResult<Catalog>(data);
                }
                return new ErrorDataResult<Catalog>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Catalog>(ex.Message);
            }
        }
    }
}
