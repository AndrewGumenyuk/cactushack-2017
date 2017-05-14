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
        [Route("current")]
        public bool UpdateProfile(int age)
        {
            if (age <= 0)
                throw new ArgumentException($"{nameof(age)} can't be lass than 0");
            //if (weight <= 0)
            //    throw new ArgumentException($"{nameof(weight)} can't be lass tahn 0");
            //if (height <= 0)
            //    throw new ArgumentException($"{nameof(height)} can't be lass than 0");

            //MemoryCasheService memoryCasheService = new MemoryCasheService();
            //UpdateProfileByUser(new Profile(age, weight, height, sex, activity), memoryCasheService);

            return true;
        }

        private static void UpdateProfileByUser(Profile model, MemoryCasheService memoryCasheService)
        {
            memoryCasheService.Delete("Profile");
            memoryCasheService.Add("Profile", model, DateTimeOffset.MaxValue);
        }

        [Route("")]
        public Profile Get()
        {
                MemoryCasheService memoryCasheService = new MemoryCasheService();
            Profile profile = memoryCasheService.GetValue("Profile") as Profile;
            return profile;
        }
    }
}