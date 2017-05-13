using System.Web.Http;
using HealthyFood.Services;
using HealthyFood.ViewModels;

namespace HealthyFood.Application.Controllers
{
    public class RecipeNewsController : ApiController
    {
        //[Route("api\v1\recipenews")]
        public Recipe[] Get()
        {
            RecipeService recipeService = new RecipeService();
            return recipeService.GetAll();
        }
    }
}