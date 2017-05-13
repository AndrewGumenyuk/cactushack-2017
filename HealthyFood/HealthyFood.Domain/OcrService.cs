using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood.Services
{
    public class OcrService
    {
        public async Task<string> GetOrcServerResponce(byte[] imageAsByteArray)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    content.Add(new StringContent("559afc6dc088957"), "\"apikey\"");
                    content.Add(new StringContent("rus"), "\"language\"");
                    content.Add(new StreamContent(new MemoryStream(imageAsByteArray)), "base64Image", "image.jpg");

                    using (var message = await client.PostAsync("https://api.ocr.space/parse/image", content))
                    {
                        var json = await message.Content.ReadAsStringAsync();
                        return json;
                    }
                }

            }
        }
    }
}
