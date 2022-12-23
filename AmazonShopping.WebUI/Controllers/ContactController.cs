using AmazonShopping.Business.Abstract;
using AmazonShopping.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendFeedBack(Contact contact)
        {
            var result = _contactService.SendFeedback(contact);
            if (result.Success)
            {
                return Json(result);
            }
            return Json(null);
        }
    }
}
