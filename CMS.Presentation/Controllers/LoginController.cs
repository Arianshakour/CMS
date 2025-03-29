using CMS.Application.Services.Interfaces;
using CMS.Domain.Common;
using CMS.Domain.Dtoes.Member;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Claims;

namespace CMS.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return PartialView();
        }
        [HttpPost]
        public IActionResult Register(RegisterDto register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_loginService.IsExistEmail(register.Email))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نیست");
                return View(register);
            }
            if (_loginService.IsExistUser(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نیست");
                return View(register);
            }
            _loginService.AddUser(register);
            return View("SuccessRegister", register);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return PartialView();
        }
        [HttpPost]
        public IActionResult Login(LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _loginService.GetMember(login);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری با مشخصات یافت شده پیدا نشد");
                return View(login);
            }
            if (user.IsActive == false)
            {
                ModelState.AddModelError("Email", "حسابت فعال نیست");
                return View(login);
            }
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Email,user.Email)
                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);
            ViewBag.IsSuccess = true;
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult LoadLogout()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login/Login");
        }
        public IActionResult ChangePassword()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Login");
            }
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var model = _loginService.ChangePass(email);
            return View(model);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassDto change)
        {
            if (!ModelState.IsValid)
            {
                return View(change);
            }
            if (!_loginService.IsCorrectPassword(change.Email, change.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "رمز فعلی اشتباه است");
                return View(change);
            }
            _loginService.UpdatePass(change);
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
