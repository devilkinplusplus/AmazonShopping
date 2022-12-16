using AmazonShopping.Business.Validators;
using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.Entities.DTOs;
using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmazonShopping.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AuthController(IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _mapper = mapper;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return View();
            var mapper = _mapper.Map<User>(model);
            mapper.Firstname = model.Firstname;
            mapper.Lastname = model.Lastname;
            mapper.Email = model.Email;
            mapper.UserName = model.Email;

            UserValidator validationRules = new UserValidator();
            ValidationResult validations = validationRules.Validate(mapper);

            if (validations.IsValid)
            {
                var result = await userManager.CreateAsync(mapper, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            foreach (var item in validations.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return View();


            var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return View(model);
        }

    }
}
