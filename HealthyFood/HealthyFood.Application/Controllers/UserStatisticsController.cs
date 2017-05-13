using System;
using System.Web.Http;
using HealthyFood.Services;
using HealthyFood.ViewModels;

namespace HealthyFood.Application.Controllers
{
    /// <summary>
    /// Class that return the Statistic for User
    /// </summary>
    /// <returns></returns>
    [RoutePrefix("api/user_statistics")]
    public class UserStatisticsController : ApiController
    {
        /// <summary>
        /// Method that return Statistic for User by route <see cref="api/user_statistics"/>
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public Statistic Get()
        {
            MemoryCasheService memoryCasheService = new MemoryCasheService();
            Profile profile = memoryCasheService.GetValue("Profile") as Profile;
            if (profile == null)
                throw new ArgumentException($"{nameof(profile)} can't null");
            Statistic statistic = new Statistic(profile);

            return statistic;
        }
    }
}