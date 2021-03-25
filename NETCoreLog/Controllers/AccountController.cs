using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NETCoreLog.Models.Identity;
using Microsoft.AspNetCore.Authorization;
namespace NETCoreLog.Controllers

{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registermodel)
        {
            if (ModelState.IsValid)
            {
                User user = new Models.Identity.User { UserName = registermodel.Email, Email = registermodel.Email };
                IdentityResult result = await _userManager.CreateAsync(user, registermodel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                    foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginmodel)
        {
            User user = new Models.Identity.User { UserName = loginmodel.Email, Email =loginmodel.Email };
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user,loginmodel.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Niepoprawne dane logowania");
            }
            return View();
        }
        [Authorize]
        public String CheckLogin()
        {
            return "Zostałeś zalogowany";
        }
    }
}
