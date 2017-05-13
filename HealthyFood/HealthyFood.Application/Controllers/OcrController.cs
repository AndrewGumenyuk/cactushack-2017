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
using HealthyFood.ViewModels;

namespace HealthyFood.Application.Controllers
{
    public class OcrController : ApiController
    {
       // api/ocr
       public async Task<IHttpActionResult> Post()
       {
            List<Eitem> returnedEitems = new List<Eitem>();

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
                //parse E
                string parsedText = Regex.Replace(ocrDto.ParsedResults[0].ParsedText, @"\s+", "");
                var eElements = Regex.Matches(parsedText, "(([Е{IsCyrillic}]{1}[0-9]{3})|([E{IsCyrillic}-]{2}[0-9]{3}))").Cast<Match>().Select(m => m.Value).ToList();

                //Get current E from MemoryCache
                MemoryCasheService memoryCache = new MemoryCasheService();
                var items = memoryCache.GetValue("ALL_EITEMS") as List<Eitem>;
                if(items != null)
                {
                    returnedEitems = items.Where(item => eElements.Contains(item.Ecode)).ToList();
                }
                return Ok(returnedEitems);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
