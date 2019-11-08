using System.IO;
using System.Net.Http.Headers;
using API_TechCycle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TechCycle.Controllers
{
    public class UploadController : ControllerBase
    {
        public string Upload(IFormFile file, string folder)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);

            if(file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);


                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return fileName;
            }
            else
            {
                return "";
            }
        }
    }
}