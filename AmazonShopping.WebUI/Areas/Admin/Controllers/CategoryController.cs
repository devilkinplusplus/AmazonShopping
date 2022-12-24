using AmazonShopping.Business.Abstract;
using AmazonShopping.DataAcces.Concrete;
using AmazonShopping.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.GetCategories();
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryService.EditCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            _categoryService.DeleteCategory(data.Data);
            return RedirectToAction(nameof(Index));
        }

    }
}
