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
            CategoryValues();
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
            CategoryValues();
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
            deletedData.IsDeleted = true;
            _productService.DeleteProduct(deletedData);
            return RedirectToAction(nameof(Index));
        }




        [NonAction]
        private void CategoryValues()
        {
            using var context = new AppDbContext();
            List<SelectListItem> categories =
                (from y in context.Categories.ToList().Where(x => x.IsDeleted == false)
                 select new SelectListItem
                 {
                     Value = y.Id.ToString(),
                     Text = y.Name
                 }).ToList();
            ViewBag.categoryValues = categories;
        }

    }
}
