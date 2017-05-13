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
using Newtonsoft.Json;
using HealthyFood.Application.Models;
using System.Text.RegularExpressions;

namespace HealthyFood.Application.Controllers
{
    public class OcrController : ApiController
    {
       // api/ocr
       public async Task<IHttpActionResult> Post()
       {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            if (file.ContentLength > 0)
            {
                //Upload Photo
                OcrService ocrService = new OcrService();
                BinaryReader binaryReader = new BinaryReader(file.InputStream);
                byte[] imageAsByteArray = binaryReader.ReadBytes(file.ContentLength);
                var json = await ocrService.GetOrcServerResponce(imageAsByteArray);
                
                //Deserialize Json
                var ocrDto = JsonConvert.DeserializeObject<OcrDto>(json);
                if (ocrDto.ErrorMessage != null || String.IsNullOrEmpty(ocrDto.ParsedResults.FirstOrDefault().ParsedText))
                {
                    return BadRequest(ocrDto.ErrorMessage.ToString());
                }

                string parsedText = Regex.Replace(ocrDto.ParsedResults[0].ParsedText, @"\s+", "");
                var eElements = Regex.Matches(ocrDto.ParsedResults.FirstOrDefault().ParsedText, "(([Е{IsCyrillic}]{1}[0-9]{3})|([E{IsCyrillic}-]{2}[0-9]{3}))").Cast<Match>().Select(m => m.Value).ToList();

                return Ok(eElements);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
