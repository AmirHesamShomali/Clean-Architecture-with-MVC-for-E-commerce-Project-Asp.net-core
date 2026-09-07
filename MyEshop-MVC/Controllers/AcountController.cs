using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Users.Commands.RegisterUser;
using MyEshop_Domain.Entities.Users;
using Services.Users.Commands.LoginUser;
using System.Security.Claims;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace MyEshop_MVC.Controllers
{
    public class AcountController : Controller
    {
        private readonly IRegisterUserService _registerUserService;

        private readonly ILoginUserService _loginUserService;
        public AcountController(IRegisterUserService registerUserService, ILoginUserService loginUserService)
        {
            _registerUserService = registerUserService;
            _loginUserService = loginUserService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RequestRegisterService requestRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(requestRegister);


            }
            var resault = _registerUserService.Execute(requestRegister);
            if (resault.IsSuccess != true)
            {
                ViewBag.Message = resault.Message;
                return View();
            }
            return View("Success");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginViewModel requestlogin)
        {
            if (!ModelState.IsValid)
            {
                return View(requestlogin);
            }
            var resault = _loginUserService.GetUserLogin(requestlogin.phone, requestlogin.Password);
            if (resault.Success == true)
            {
                var claims = new List<Claim>
                {
            new Claim(ClaimTypes.NameIdentifier, resault.user.Id.ToString()),
            new Claim(ClaimTypes.Name, resault.user.FullName),
            new Claim(ClaimTypes.MobilePhone, resault.user.phone),

            new Claim("IsAdmin", resault.user.IsAdmin.ToString())
               };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = requestlogin.Rememberme
                };

                 await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                     principal,
                     properties);

                return Redirect("/");
            }
            ViewBag.Message = resault.Message;
            return View();
        }

        public IActionResult logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("login");
        }
    }
}
