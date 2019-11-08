using System.IO;
using System.Net.Http.Headers;
using API_TechCycle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TechCycle.Controllers
{
    public class UploadController : ControllerBase
    {
        /// <summary>
        /// Tem a função de adicionar uma foto de perfil do usúario e fotos de anúncios.
        /// </summary>
        /// <param name="file">Passa o arquivo da foto..</param>
        /// <param name="folder">Passa a pasta a onde a foto vai ser salva.</param>
        /// <returns>Retorna a foto adicionada no sistema.</returns>
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