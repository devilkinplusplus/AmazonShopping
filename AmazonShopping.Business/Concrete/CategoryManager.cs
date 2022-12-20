using AmazonShopping.Business.Abstract;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CreateCategory(Category category)
        {
            try
            {
                if (category.Name != null)
                    _categoryDal.Add(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCategory(Category category)
        {
            try
            {
                var data = _categoryDal.Get(x => x.Id == category.Id);
                data.IsDeleted = true;
                _categoryDal.Update(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditCategory(Category category)
        {
            try
            {
                var data = _categoryDal.Get(x => x.Id == category.Id);
                data.Name = category.Name;
                _categoryDal.Update(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryDal.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.Get(x => x.Id == id);
        }
    }
}
