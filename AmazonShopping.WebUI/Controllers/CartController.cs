using AmazonShopping.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AmazonShopping.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IFavouritService _favouritService;

        public CartController(IFavouritService favouritService)
        {
            _favouritService = favouritService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = _favouritService.GetFavouritList(userId);
            return View(values);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var data =_favouritService.Edit(id);
            return Json(data);
        }


    }
}
