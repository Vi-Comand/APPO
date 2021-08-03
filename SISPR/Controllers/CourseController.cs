using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISPR.Models;
using System.Diagnostics;
using Dadata;
using Dadata.Model;
using System.Threading.Tasks;
using System.Text.Json;

namespace SISPR.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public string token = "849df9cd46f8aa00925f2033914543026fe5af1f";
        public string secret = "366e5b7bd413da10837fd15f91c5120ff69289e1";
        public CourseController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult AddCourse()
        {


            return View();
        }


        async public Task<IActionResult> AdresAjax(string adr)
        {
            string city, val;
            var api = new SuggestClientAsync(token);
            SuggestAddressRequest a = new SuggestAddressRequest(adr, 1)
            {
                from_bound = new AddressBound("city"),
                to_bound = new AddressBound("settlement"),
                /* locations = new[] { new Address() { area = "Кущевский" } }*/
            };
            var result = await api.SuggestAddress(a);
            for (int i = 0; i < 10 && result.suggestions.Count == 0; i++)
                result = await api.SuggestAddress(a);
            city = result.suggestions[0].data.city_with_type ?? result.suggestions[0].data.settlement_with_type;
            val = result.suggestions[0].value;
            return Json(val);
        }

        public IActionResult CreateRaspisan()
        {
            return View();
        }


    }
}