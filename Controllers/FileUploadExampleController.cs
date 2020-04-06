using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadExample.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FileUploadExample.Controllers
{
    public class FileUploadExampleController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileUploadExampleController> _logger;

        public FileUploadExampleController(IWebHostEnvironment env, ILogger<FileUploadExampleController> logger)
        {
            _env = env;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(FileUpload fileUpload)
        {
            ViewBag.Error = "No";
            if(fileUpload.FormFile!= null)
            {
                var postedFileExtension = Path.GetExtension(fileUpload.FormFile.FileName);
                if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    TempData["Message"] = "Not Accepted";
                    return Redirect("Index");
                }
                else
                {
                    TempData["Message"] = "Success";
                    string filePath = $"{_env.WebRootPath}/images/{fileUpload.FormFile.FileName}";
                    var stream = System.IO.File.Create(filePath);
                    fileUpload.FormFile.CopyTo(stream);
                }
            }
            return Redirect("/");
        }
        
    }
}