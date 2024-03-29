﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using SISPR.Models;

namespace SISPR.Controllers
{
    public class UploadFileController : Controller
    {
        //ApplicationContext _context;

        //public UploadFileController(ApplicationContext context)
        //{
        //    _context = context;

        //}
        public IActionResult Index()
        {
            return View("UploadFile");
        }


        //public async void  AddFile(IFormFileCollection uploads)
        //{
        //    foreach (var uploadedFile in uploads)
        //    {
        //        // путь к папке Files
        //        string path = "/wwwroot/Files/" + uploadedFile.FileName;
        //        // сохраняем файл в папку Files в каталоге wwwroot
        //        using (var fileStream = new FileStream(Directory.GetCurrentDirectory() + path, FileMode.Create))
        //        {
        //            await uploadedFile.CopyToAsync(fileStream);
        //        }
        //        FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
        //        //   _context.Files.Add(file);
        //    }
        //    // _context.SaveChanges();

           
        //}
        public async Task<string> AddFile(IFormFile upload)
        {
          
          
                // путь к папке Files
                string path = "/wwwroot/Files/" + upload.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(Directory.GetCurrentDirectory() + path, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }

                FileModel file = new FileModel { Name = upload.FileName, Path = path };
             //   _context.Files.Add(file);
            
           // _context.SaveChanges();
          
            return path;
        }
    }
}