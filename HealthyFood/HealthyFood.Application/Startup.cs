using System;
using System.Collections.Generic;
using System.Linq;
using HealthyFood.Services;
using HealthyFood.ViewModels;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HealthyFood.Application.Startup))]

namespace HealthyFood.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //TODO: Only for Demo
            //SETUP PROFILE DATA
            MemoryCasheService memoryCasheService = new MemoryCasheService();
            memoryCasheService.Add("Profile", new Profile(21, 180, 32, 0,PhysicalActivity.Average) , DateTimeOffset.MaxValue);
            //SETUP EITEMS DATA
            var eitems = OcrService.GetAllEitems();
            memoryCasheService.Add("ALL_EITEMS", eitems, DateTimeOffset.MaxValue);

            ConfigureAuth(app);
        }
    }
}
