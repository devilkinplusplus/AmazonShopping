using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IEnumerable<Category>> GetCategories();
        IDataResult<IEnumerable<Category>> GetCategories(int size,int page);
        IDataResult<Category> GetCategoryById(int id);
        IResult CreateCategory(Category category);
        IResult EditCategory(Category category);
        IResult DeleteCategory(Category category);

    }
}
