using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }

        public async Task<IActionResult> AddRole(string id)
        {
            if (id == null)
                return NotFound();

            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            var roles = _roleManager.Roles.Select(role => role.Name).ToList();
            AddUserRoleVM addUserRoleVM = new()
            {
                User = user,
                Roles = roles.Except(userRoles),
            };
            return View(addUserRoleVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {
            if (id == null) return NotFound();

            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userManager.AddToRoleAsync(user, role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


    }
}
