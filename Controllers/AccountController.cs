using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = register.Email,
                    Email = register.Email,
                    FirstName = register.FirstName,
                    LastName = register.LastName
                };

                var result = await _userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError("", "Nieprawidłowa próba rejestrowania.");
            }
            return View(register);
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new Login
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(login.Name);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, login.Password, false, false)).Succeeded)
                    {
                        return Redirect(login?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Nieprawidłowa dane logowania.");

            return View(login);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
