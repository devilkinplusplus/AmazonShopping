using AmazonShopping.Business.Abstract;
using AmazonShopping.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static AmazonShopping.Entities.DTOs.ContactDTO;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IReplyService _replyService;
        public ContactController(IContactService contactService, IReplyService replyService)
        {
            _contactService = contactService;
            _replyService = replyService;
        }

        public IActionResult Index(int page = 1)
        {
            var values = _contactService.GetFeedbacks(10,page);
            if (values.Success)
                return View(values);
            return View();
        }

        [HttpPost]
        public JsonResult Reply(ReplyDTO reply)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _replyService.ReplyFeedback(reply, userId);
            if (result.Success)
            {
                return Json(result);
            }
            return Json(null);
        }

        [HttpPost]
        public JsonResult DeleteFeedback(int id)
        {
            var data = _contactService.DeleteFeedback(id);
            return Json(data);
        }

        [HttpPost]
        public JsonResult DeleteReply(int id)
        {
            var data = _replyService.DeleteReply(id);
            return Json(data);
        }


        public IActionResult Sent()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = _replyService.GetReplies(userId);
            if (values.Success)
                return View(values);
            return View();
        }

    }
}
