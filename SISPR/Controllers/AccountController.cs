using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SISPR.Controllers.Service;
using SISPR.Models.DataBase;
using SISPR.Models.DataBase.Basic.Location;
using SISPR.Models.DataBase.Basic.User;
using SISPR.Models.ViewModels;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using SISPR.Controllers.Service;
using SISPR.Models.DataBase;


namespace SISPR.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private IdentityContext Context;
        private Context ContextDB;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IdentityContext context, Context contextDB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Context = context;
            ContextDB = contextDB;
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

            if (!Context.Users.Any(x => x.Email.ToLower() == Email.ToLower()))
            {
                var checkKod = new CheckKod();


                Random rnd = new Random();
                int _min = 1000;
                int _max = 9999;
                var ConfirmKod = rnd.Next(_min, _max);

                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(Email, "Подтверждение Email", ConfirmKod.ToString());
                checkKod.hash = HashPass(ConfirmKod.ToString());
                checkKod.messege = $"На почту {Email} отправлено код для подтверждения!";
                return Json(checkKod);
            }
            else
            {
                var checkKod = new CheckKod();
                checkKod.messege = $" {Email} уже используется!";
                return Json(checkKod);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CheckKod(int kod, string HashKod)
        {
            if (HashPass(kod.ToString()) == HashKod)
                return Json("true");


            return Json("false");
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

                if (await ContextDB.Region.AnyAsync(x => x.fias_code == model.Region.fias_code))
                    model.Region = await ContextDB.Region.FirstAsync(x => x.fias_code == model.Region.fias_code);
                else
                {


                    ContextDB.Region.Add(model.Region);

                    ContextDB.SaveChanges();

                }
                if (await ContextDB.MO.AnyAsync(x => x.fias_code == model.MO.fias_code))
                    model.MO = await ContextDB.MO.FirstAsync(x => x.fias_code == model.MO.fias_code);
                else
                {

                    model.MO.region_id = model.Region.region_id;
                    ContextDB.MO.Add(model.MO);

                    ContextDB.SaveChanges();
                }

                if (await ContextDB.City.AnyAsync(x => x.fias_code == model.City.fias_code))
                    model.City = await ContextDB.City.FirstAsync(x => x.fias_code == model.City.fias_code);
                else
                {

                    model.City.mo_id = model.MO.mo_id;
                    ContextDB.City.Add(model.City);

                    ContextDB.SaveChanges();

                }


                if (await ContextDB.OO.AnyAsync(x => x.inn == model.OO.inn))
                    model.OO = await ContextDB.OO.FirstAsync(x => x.inn == model.OO.inn);
                else
                {

                    model.OO.city_id = model.City.city_id;
                    ContextDB.OO.Add(model.OO);

                    ContextDB.SaveChanges();

                }


                User user = new User
                {
                    Email = model.Email,
                    f = model.F,
                    i = model.I,
                    o = model.O,
                    PasswordHash = HashPass(model.Password),
                    PhoneNumber = model.PhoneNumber,
                    snils = ulong.Parse(string.Join("", model.SNILS.Where(c => char.IsDigit(c)))),
                    region_id = model.Region.region_id,
                    mo_id
                = model.MO.mo_id,
                    city_id = model.City.city_id,
                    oo_id = model.OO.oo_id
                };

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

        public string token = "849df9cd46f8aa00925f2033914543026fe5af1f";

        async public Task<IActionResult> RegionAjax(string adr)
        {
            var api = new SuggestClientAsync(token);
            SuggestAddressRequest a = new SuggestAddressRequest(adr, 1)
            {
                from_bound = new AddressBound("region"),
                to_bound = new AddressBound("region"),
                /* locations = new[] { new Address() { area = "Кущевский" } }*/
            };
            var result = await api.SuggestAddress(a);
            for (int i = 0; i < 10 && result.suggestions.Count == 0; i++)
                result = await api.SuggestAddress(a);
            Region region = new Region();
            try
            {
                region.name = result.suggestions[0].data.region_with_type;
                region.search_name = result.suggestions[0].data.region;
                region.fias_code = result.suggestions[0].data.fias_code;
            }
            catch
            {
                region.region_id = -30;
            }
            return Json(region);
        }

        async public Task<IActionResult> MoAjax(string adr, string reg)
        {
            var api = new SuggestClientAsync(token);
            SuggestAddressRequest a = new SuggestAddressRequest(adr, 1)
            {
                from_bound = new AddressBound("area"),
                to_bound = new AddressBound("area"),
                locations = new[] { new Address() { region = reg } }
            };
            var result = await api.SuggestAddress(a);
            for (int i = 0; i < 5 && result.suggestions.Count == 0; i++)
                result = await api.SuggestAddress(a);
            if (result.suggestions.Count == 0)
            {
                a = new SuggestAddressRequest(adr, 1)
                {
                    from_bound = new AddressBound("area"),
                    to_bound = new AddressBound("city"),
                    locations = new[] { new Address() { region = reg } }
                };
                result = await api.SuggestAddress(a);
                for (int i = 0; i < 5 && result.suggestions.Count == 0; i++)
                    result = await api.SuggestAddress(a);
            }
            MO mo = new MO();
            try
            {
                mo.name = result.suggestions[0].data.area_with_type ?? result.suggestions[0].data.city_with_type;
                mo.searсh_name = result.suggestions[0].data.area ?? result.suggestions[0].data.city;
                mo.fias_code = result.suggestions[0].data.fias_code;
                if (result.suggestions[0].data.area == null)
                    mo.region_id = -10;
                if (result.suggestions[0].data.city_with_type == null && result.suggestions[0].data.area_with_type == null)
                    mo.region_id = -20;
            }
            catch
            {
                mo.region_id = -30;
            }
            return Json(mo);
        }

        async public Task<IActionResult> CityAjax(string adr, string reg, string mo)
        {
            var api = new SuggestClientAsync(token);
            SuggestAddressRequest a = new SuggestAddressRequest(adr, 1)
            {
                from_bound = new AddressBound("city"),
                to_bound = new AddressBound("settlement"),
                locations = new[] { new Address() { region = reg, area = mo } }
            };
            var result = await api.SuggestAddress(a);
            for (int i = 0; i < 10 && result.suggestions.Count == 0; i++)
                result = await api.SuggestAddress(a);
            City city = new City();
            try
            {
                city.name = result.suggestions[0].data.city_with_type ?? result.suggestions[0].data.settlement_with_type;
                city.search_name = result.suggestions[0].data.city ?? result.suggestions[0].data.settlement;
                city.fias_code = result.suggestions[0].data.fias_code;
                if (result.suggestions[0].data.area == null)
                    city.mo_id = -10;
                if (result.suggestions[0].data.city_with_type == null && result.suggestions[0].data.area_with_type == null)
                    city.mo_id = -20;
            }
            catch
            {
                city.mo_id = -30;
            }
            return Json(city);
        }




        async public Task<IActionResult> OoAjax(string adr, string reg, string mo, string city)
        {
            var api = new SuggestClientAsync(token);
            /* SuggestPartyRequest a = new SuggestPartyRequest(adr, 1)
             {

                 locations = new[] { new Address() { region = "Краснодарский", area = "Кущевский" } }
             };*/
            var result = await api.SuggestParty(adr + " " + reg + " " + mo + " " + city);
            for (int i = 0; i < 10 && result.suggestions.Count == 0; i++)
                result = await api.SuggestParty(adr + " " + reg + " " + mo + " " + city);
            OO oo = new OO();
            try
            {
                oo.name = result.suggestions[0].data.name.full;
                oo.name_short = result.suggestions[0].data.name.@short;
                oo.inn = result.suggestions[0].data.inn;
            }
            catch
            {
                oo.oo_id = -30;
            }
            return Json(oo);
        }


        public async Task<IActionResult> CheckSnilsAjax(string Snils1)
        {
            ulong snils = ulong.Parse(string.Join("", Snils1.Where(c => char.IsDigit(c))));
            if (!Context.Users.Any(x => x.snils == snils))
            {
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
    }
}