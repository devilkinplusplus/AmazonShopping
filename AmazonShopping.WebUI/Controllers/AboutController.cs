using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
