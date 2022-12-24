using AmazonShopping.Business.Abstract;
using AmazonShopping.Entities.Concrete;
using AmazonShopping.WebUI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFavouritService _favouritService;
        public HomeController(IProductService productService, IFavouritService favouritService)
        {
            _productService = productService;
            _favouritService = favouritService;
        }

        public IActionResult Index()
        {
            var newProducts = _productService.NewProducts();
            var trendingProducts = _productService.TrendingProducts();
            HomeVM home = new()
            {
                NewProducts = newProducts.Data,
                TrendingProducts = trendingProducts.Data
            };
            if(newProducts.Success && trendingProducts.Success)
                return View(home);
            return View();
        }

        [HttpPost]
        public JsonResult AddToFavourits(AddToFavourits favourit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _favouritService.Add(favourit, userId);
            if (result.Success)
            {
                return Json(result);
            }
            return Json(null);
        }


    }
}
