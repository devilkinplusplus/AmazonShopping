using AmazonShopping.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly IProductService _productService;

        public CatagoryController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id, int page = 1)
        {
            var values = _productService.GetAllProducts(id,5,page);
            if (values.Success)
                return View(values);
            return View();
        }
    }
}
