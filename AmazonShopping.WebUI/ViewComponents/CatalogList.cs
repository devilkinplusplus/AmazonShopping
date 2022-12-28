using AmazonShopping.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.ViewComponents
{
    public class CatalogList:ViewComponent
    {
        private readonly ICatalogService _catalogService;

        public CatalogList(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _catalogService.GetAllCatalogs();
            if(values.Success)
                return View(values);
            return View();
        }

    }
}
