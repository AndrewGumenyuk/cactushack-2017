using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HealthyFood.ViewModels;
using System.Collections.Generic;

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
        public static List<Eitem>  GetAllEitems()
        {
            List<Eitem> eitemsList = new List<Eitem>()
            {
                new Eitem()
                {
                    Ecode = "Е476",
                    DangerLevel = "низкая",
                    Type = "Эмульгаторы",
                    RealName = "Полиглицерин",
                    Description = "Полиглецирин.Добавка применяется в производстве шоколадных изделий.В последнее время довольно часто полиглицерин (E476) получают путем переработки генетически-модифицированных продуктов (ГМО)."
                },

             };

            return eitemsList;
        }
    }
}
