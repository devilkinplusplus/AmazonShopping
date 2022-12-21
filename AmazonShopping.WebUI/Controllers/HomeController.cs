using AmazonShopping.Business.Abstract;
using AmazonShopping.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var newProducts = _productService.NewProducts();
            var trendingProducts = _productService.TrendingProducts();
            HomeVM home = new()
            {
                NewProducts = newProducts,
                TrendingProducts= trendingProducts
            };
            return View(home);
        }

      
    }
}
