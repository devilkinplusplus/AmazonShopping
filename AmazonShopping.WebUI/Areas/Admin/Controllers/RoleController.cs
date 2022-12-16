using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            if (!ModelState.IsValid)
            {
                return View(identityRole);
            }
            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _roleManager.FindByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole identityRole)
        {
            var data = await _roleManager.FindByIdAsync(identityRole.Id);
            if (!ModelState.IsValid)
            {
                return View(identityRole);
            }
            data.Name = identityRole.Name;

            IdentityResult result = await _roleManager.UpdateAsync(data);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(result);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var deletedData = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(deletedData);
            return RedirectToAction(nameof(Index));
        }

    }
}
