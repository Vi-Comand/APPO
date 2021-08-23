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
using System.Threading.Tasks;

namespace SISPR.Controllers
{
    public class UTPController : Controller
    {
     

        public async Task<IActionResult> Index()
        {
                return View();
            
        }
        public async Task<IActionResult> Add()
        {
            return RedirectToAction("Index", "UploadFile");

        }
    }
}