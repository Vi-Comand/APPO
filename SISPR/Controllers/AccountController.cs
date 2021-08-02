using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SISPR.Models.DataBase.Basic.User;
using SISPR.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SISPR.Controllers.Service;
using SISPR.Models.DataBase;

namespace SISPR.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private IdentityContext Context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IdentityContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Context = context;

        }



        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }


        public async Task<IActionResult> ConfirmedEmailAjax(string Email)
        {
            Random rnd=new Random();
            int _min = 1000;
            int _max = 9999;
            var ConfirmKod=rnd.Next(_min, _max);
            // генерация токена для пользователя
           // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //var callbackUrl = Url.Action("ConfirmEmail","Account",
            //    new { userId = user.Id, code = code },
            //    protocol: HttpContext.Request.Scheme);
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("hde@iro23.info", "Confirm your account",
                $"Подтвердите регистрацию, перейдя по ссылке: '{ConfirmKod}'");

            return Json("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");



        }


        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
          


            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email,f = model.F, i=model.I,o=model.O ,PasswordHash = HashPass (model.Password) };
                Context.Users.Add(user);
                Context.SaveChanges();
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {








                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("Login");
        }

        private string HashPass(string password)
        {

            

            //generate a 128 - bit salt using a secure PRNG
            string a = "Проект_Яна";

            byte[] salt = Encoding.Default.GetBytes(a);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
