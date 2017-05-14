using HealthyFood.Services;
using HealthyFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HealthyFood.Application.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public bool Get(int age, int height, byte sex, int weight, int activity = 0)
        {
            if (age <= 0)
                throw new ArgumentException($"{nameof(age)} can't be lass than 0");
            if (weight <= 0)
                throw new ArgumentException($"{nameof(weight)} can't be lass tahn 0");
            if (height <= 0)
                throw new ArgumentException($"{nameof(height)} can't be lass than 0");

            MemoryCasheService memoryCasheService = new MemoryCasheService();
            var physicalActivity = (PhysicalActivity)activity;
            UpdateProfileByUser(new Profile(age, weight, height, sex, physicalActivity), memoryCasheService);
            return true;
        }

        private static void UpdateProfileByUser(Profile model, MemoryCasheService memoryCasheService)
        {
            memoryCasheService.Delete("Profile");
            memoryCasheService.Add("Profile", model, DateTimeOffset.MaxValue);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
