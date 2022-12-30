using AmazonShopping.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AmazonShopping.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IFavouritService _favouritService;

        public ProfileController(IFavouritService favouritService)
        {
            _favouritService = favouritService;
        }

        public IActionResult Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = _favouritService.GetFavouritList(id);
            if (values.Success)
                return View(values);
            return View();
        }
    }
}
