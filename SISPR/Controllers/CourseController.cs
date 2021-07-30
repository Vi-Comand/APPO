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

        class xz
        {
            public string query { get; set; }
            public string from_bound { get; set; }
            public string to_bound { get; set; }

        }
        async public Task<IActionResult> AdresAjax(string adr)
        {

            //var api = new CleanClientAsync(token, secret);
            //var address = await api.Clean<Address>(adr);
            //string city = address.result; 
            //var response = await api.Find<PostalUnit>(> "127642");
            //var unit = response.suggestions[0].data;
            //return Json(city);
            string region, mo, city, val;
            var api = new SuggestClientAsync(token);
            //  string qw = JsonSerializer.Serialize<xz>(new xz { query = "Красное", from_bound = "city", to_bound = "settlement" });
            Address[] address = new Address[1];
            SuggestAddressRequest a = new SuggestAddressRequest(adr, 1) { from_bound = new AddressBound("city"), to_bound = new AddressBound("settlement"), locations = new Address[1] };

            var result = await api.SuggestAddress(a);
            region = result.suggestions[0].data.region_with_type;
            mo = result.suggestions[0].data.area_with_type == null ? result.suggestions[0].data.city_with_type : result.suggestions[0].data.area_with_type;
            city = result.suggestions[0].data.city_with_type == null ? result.suggestions[0].data.settlement_with_type : result.suggestions[0].data.city_with_type;
            val = result.suggestions[0].value;

            return Json(val);


        }

        public IActionResult CreateRaspisan()
        {
            return View();
        }


    }
}