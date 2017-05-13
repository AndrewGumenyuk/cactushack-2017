using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using HealthyFood.Services;
namespace HealthyFood.Application.Controllers
{
    public class OcrController : ApiController
    {
       public async Task<IHttpActionResult> Post()
       {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            if (file.ContentLength > 0)
            {
                OcrService ocrService = new OcrService();
                BinaryReader binaryReader = new BinaryReader(file.InputStream);
                byte[] imageAsByteArray = binaryReader.ReadBytes(file.ContentLength);
                var json = await ocrService.GetOrcServerResponce(imageAsByteArray);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
