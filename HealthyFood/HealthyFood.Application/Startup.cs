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
            MemoryCasheService memoryCasheService = new MemoryCasheService();
            memoryCasheService.Add("Profile", new Profile(21, 180, 32, PhysicalActivity.Average) , DateTimeOffset.MaxValue);

            ConfigureAuth(app);
        }
    }
}
