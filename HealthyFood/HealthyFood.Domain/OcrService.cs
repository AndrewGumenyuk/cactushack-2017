using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HealthyFood.ViewModels;

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
                new Eitem()
                {
                    Ecode = "E471",
                    DangerLevel = "низкая",
                    Type = "Стабилизаторы",
                    RealName = "диглицериды",
                    Description = "E471 - пищевая добавка используемая в качестве стабилизатора и эмульгатора.Добавка имеет натуральное происхождение. Основное назначение данной добавки - получение из веществ, которые в природе не смешиваются однородной массы. В качестве примера можно сказать что при помощи добавки E471 можно без проблем смешать растительное масло и воду. Именно поэтому добавка наиболее часто используется при приготовлении молочных продуктов и жирных продуктов."
                },
                new Eitem()
                {
                    Ecode = "E1520",
                    DangerLevel = "низкая",
                    Type = "Влагоудерживающие агенты",
                    RealName = "Пропиленгликоль",
                    Description = "Пропиленгликоль (пищевая добавка E1520) – вязкая жидкость, не обладающая цветом, но имеющая слабый характерный запах и сладковатый вкус.Пропиленгликоль практически не токсичен, и не опасен при случайном вдыхании или приеме внутрь. Но специально дышать парами пропиленгликоля все же не следует"
                },
                new Eitem()
                {
                    Ecode = "E621",
                    DangerLevel = "низкая",
                    Type = "Влагоудерживающие агенты",
                    RealName = "Усилитли вкуса и аромата",
                    Description = "Пищевая добавка E621 известна как глутамат натрия и представляет собой соль натрия, встречающуюся в природе в неосновных аминокислотах глутаминовой кислоты. В пищевой промышленности глутамат натрия используется в качестве усилителя вкуса."
                },
                new Eitem()
                {
                    Ecode = "E451",
                    DangerLevel = "средния",
                    Type = "Комплексообразователи",
                    RealName = "Трифосфаты",
                    Description = "Трифосфат гидролизуется в кишечнике на более мелкие единицы (ортофосфаты) , которые при больших количествах могут вызвать метаболический ацидоз."
                },
                new Eitem()
                {
                    Ecode = "E450",
                    DangerLevel = "средния",
                    Type = "Эмульгаторы",
                    RealName = "Пирофосфат",
                    Description = "Добавки E450 относятся к группе пирофосфатов — солей и эфиров пирофосфорной кислоты.При чрезмерном употреблении добавки, она может вызывать расстройство желудка, а также нарушения, связанные с дисбалансом фосфора и кальция в организме."
                }
             };

            return eitemsList;
        }
    }
}
