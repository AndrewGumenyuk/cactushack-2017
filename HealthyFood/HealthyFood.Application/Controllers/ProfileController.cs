using System;
using System.Web.Http;
using HealthyFood.Services;
using HealthyFood.ViewModels;

namespace HealthyFood.Application.Controllers
{
    /// <summary>
    /// Class that return the Profiles for User
    /// </summary>
    /// <returns></returns>
    [RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        /// <summary>
        /// Method that return all Profile for User by route <see cref="api/profileuser/>
        /// </summary>`
        /// <returns>return bool was profile saved or no</returns>
        [Route("")]
        public bool AddProfile([FromBody] Profile model)
        {
            if (model.Age <= 0)
                throw new ArgumentException($"{nameof(model.Age)} can't be lass than 0");
            if (model.Weight <= 0)
                throw new ArgumentException($"{nameof(model.Weight)} can't be lass than 0");
            if (model.Height <= 0)
                throw new ArgumentException($"{nameof(model.Height)} can't be lass than 0");

            MemoryCasheService memoryCasheService = new MemoryCasheService();
            memoryCasheService.Add("Profile", model, DateTimeOffset.MaxValue);

            return true;
        }
    }
}