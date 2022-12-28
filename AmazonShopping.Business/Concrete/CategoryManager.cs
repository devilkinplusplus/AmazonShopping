using AmazonShopping.Business.Abstract;
using AmazonShopping.Business.Constants;
using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult;
using AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AmazonShopping.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult CreateCategory(Category category)
        {
            try
            {
                if (category.Name != null)
                {
                    _categoryDal.Add(category);
                    return new SuccessResult(Messages.SuccessMessage);
                }
                return new ErrorResult(Messages.ErrorMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult DeleteCategory(Category category)
        {
            try
            {
                var data = _categoryDal.Get(x => x.Id == category.Id);
                data.IsDeleted = true;
                _categoryDal.Update(data);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult EditCategory(Category category)
        {
            try
            {
                var data = _categoryDal.Get(x => x.Id == category.Id);
                data.Name = category.Name;
                _categoryDal.Update(data);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var values = _categoryDal.GetAll(x => x.IsDeleted == false);
                if (values.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Category>>(values);
                return new ErrorDataResult<IEnumerable<Category>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Category>>(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Category>> GetCategories(int size, int page)
        {
            try
            {
                var values = _categoryDal.GetAll(x => x.IsDeleted == false).ToPagedList(page,size);
                if (values.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Category>>(values);
                return new ErrorDataResult<IEnumerable<Category>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Category>>(ex.Message);
            }
        }

        public IDataResult<Category> GetCategoryById(int id)
        {
            try
            {
                var values = _categoryDal.Get(x => x.Id == id);
                if(values!=null)
                    return new SuccessDataResult<Category>(values);
                return new ErrorDataResult<Category>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Category>(ex.Message);
            }
        }
    }
}
