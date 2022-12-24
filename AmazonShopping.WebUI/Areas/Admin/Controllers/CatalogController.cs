using AmazonShopping.Business.Abstract;
using AmazonShopping.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            var values = _catalogService.GetAllCatalogs();
            if(values.Success)
                return View(values);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catalog catalog)
        {
            _catalogService.CreateCatalog(catalog);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var data = _catalogService.GetCatalogById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Catalog catalog)
        {
            _catalogService.EditCatalog(catalog);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var data = _catalogService.GetCatalogById(id);
            _catalogService.DeleteCatalog(data.Data);
            return RedirectToAction(nameof(Index));
        }

    }
}
