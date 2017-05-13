using System.Web.Http;
using HealthyFood.Services;
using HealthyFood.ViewModels;

namespace HealthyFood.Application.Controllers
{
    /// <summary>
    /// Class that return the Recipes for User
    /// </summary>
    /// <returns></returns>
    public class RecipeNewsController : ApiController
    {
        /// <summary>
        /// Method that return all Recipes for User by route <see cref="api/recipenews"/>
        /// </summary>
        /// <returns></returns>
        public Recipe[] Get()
        {
            MemoryCasheService memoryCasheService = new MemoryCasheService();
            var profile = memoryCasheService.GetValue("Profile");
            RecipeService recipeService = new RecipeService();
            return recipeService.GetAll();
        }
    }
}