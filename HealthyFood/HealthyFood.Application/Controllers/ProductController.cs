using System;
using System.Linq;
using System.Web.Http;
using HealthyFood.Services;
using HealthyFood.ViewModels;

namespace HealthyFood.Application.Controllers
{
    /// <summary>
    /// Class that return the Profiles for User
    /// </summary>
    /// <returns></returns>
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        /// <summary>
        /// Method that return all Profile for User by route <see cref="api/products>
        /// </summary>`
        /// <returns></returns>
        [Route("")]
        public Product[] GetByPhysicalActivityType()
        {
            MemoryCasheService memoryCasheService = new MemoryCasheService();
            Profile profile = memoryCasheService.GetValue("Profile") as Profile;
            if (profile == null)
                throw new ArgumentException($"{nameof(profile)} can't be null");

            ProductService productService = new ProductService();
            Statistic statistic = new Statistic(profile);
            var result = productService.GeTypeAggregatesByCalories(statistic.Proteins);
            return result.ToArray();
        }
    }
}