using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Entities;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return RedirectToAction("Index", "Home");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Index", "Home");
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
