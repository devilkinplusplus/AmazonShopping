using AmazonShopping.Business.Abstract;
using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.DataAcces.Concrete;
using AmazonShopping.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        public ProductController(IProductService productService, UserManager<User> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var result = _productService.GetAllActiveProducts();
            return View(result);
        }

        public IActionResult Create()
        {
            CategoryAndCatalogValues();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _productService.CreateProduct(model, userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var data = _productService.GetProduct(id);
            CategoryAndCatalogValues();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EditProductDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _productService.EditProduct(model,userId);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var deletedData = _productService.GetProduct(id);
            _productService.DeleteProduct(deletedData.Data);
            return RedirectToAction(nameof(Index));
        }




        [NonAction]
        private void CategoryAndCatalogValues()
        {
            using var context = new AppDbContext();
            List<SelectListItem> categories =
                (from y in context.Categories.ToList().Where(x => x.IsDeleted == false)
                 select new SelectListItem
                 {
                     Value = y.Id.ToString(),
                     Text = y.Name
                 }).ToList();

            List<SelectListItem> catalogs =
            (from y in context.Catalogs.ToList().Where(x => x.IsDeleted == false)
             select new SelectListItem
             {
                 Value = y.Id.ToString(),
                 Text = y.Name
             }).ToList();
            ViewBag.categoryValues = categories;
            ViewBag.catalogValues = catalogs;
        }

    }
}
