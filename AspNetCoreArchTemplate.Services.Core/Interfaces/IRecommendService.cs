using EatHealthy.Web.ViewModels.Day;
using EatHealthy.Web.ViewModels.Meal;
using EatHealthy.Web.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Services.Core.Interfaces
{
   
    public interface IRecommendService
    {
        Task<IEnumerable<MealViewmodel>> RecommendDaysAsync(Guid userId);
        Task<IEnumerable<MealViewModel>> RecommendMealsAsync(Guid userId);
        Task<IEnumerable<RecipeViewModel>> RecommendRecipesAsync(Guid userId);
    }
}
