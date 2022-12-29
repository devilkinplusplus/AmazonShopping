using AmazonShopping.Business.Validators;
using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.DataAcces.Concrete;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static AmazonShopping.Entities.DTOs.UserDTO;

namespace AmazonShopping.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IMapper _mapper;
        public ProfileController(UserManager<User> userManager, IMapper mapper, IPasswordValidator<User> passwordValidator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> EditUser(EditUserDTO data)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(id);
            var mapper = _mapper.Map<User>(data);
            UserValidator validationRules = new UserValidator();

            var newHashedPass = _userManager.PasswordHasher.HashPassword(user, data.password);
            user.Firstname = data.firstName;
            user.Lastname = data.lastName;
            user.PasswordHash = newHashedPass;
            ValidationResult result = validationRules.Validate(user);

            var isPasswordCorrect = await _passwordValidator.ValidateAsync(_userManager, user, data.password);
            
            if (result.IsValid && isPasswordCorrect.Succeeded)
            {
                await _userManager.UpdateAsync(user);
                return Json(user);
            }
            return Json(null);
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
