using AmazonShopping.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AmazonShopping.WebUI.ViewComponents
{
    public class CategoriesInLayout : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesInLayout(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetCategories();
            return View(values);
        }
    }
}
