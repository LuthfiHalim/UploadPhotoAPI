using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UploadPhotoAPI.Controllers
{
    [ApiController]
    [Route("upload")]
    public class UploadPhotoController : ControllerBase
    {

        private readonly ILogger<UploadPhotoController> _logger;

        public UploadPhotoController(ILogger<UploadPhotoController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("hello")]
        public IActionResult AddUser()
        {
            var userData = new User
            {
                email = "john@pantau.com",
                profile = "hello world",
                username = "johni"
            };
            return Ok(userData);
        }
        [HttpPost]
        [Route("image")]
        public async Task<IActionResult> UploadImage()
        {
            var files = Request.Form.Files;
            var folderPath = Path.Combine("resource", "images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);

            if (files.Count > 0)
            {
                //var dbPath = new List<string>();
                var savePath = "";
                foreach (var item in files)
                {
                    var fileName = $"{Guid.NewGuid()}{item.FileName}";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    savePath = Path.Combine(folderPath, fileName);
                    savePath = savePath.Replace("\\","//");
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                }
                var data = new Data
                {
                    success = true,
                    message = "Upload Photo Berhasil",
                    data = new File { 
                        path = savePath
                    }
                };
                return Ok(data);
            }
            return BadRequest();
        }
    }
}