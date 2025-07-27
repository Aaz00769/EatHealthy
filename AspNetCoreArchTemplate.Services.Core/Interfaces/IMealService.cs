using EatHealthy.Data.Models;
using EatHealthy.Web.ViewModels.Meal;
using EatHealthy.Web.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Services.Core.Interfaces
{
    public interface IMealService
    {
        Task CreateMealAsync(Guid userId, MealFormInputModel model);
        Task AddRecipeToMealAsync(Guid mealId, Guid recipeId);
        Task<MealViewModel?> GetMealByIdAsync(Guid id);
        Task<IEnumerable<MealViewModel>> GetUserMealsAsync(Guid userId);
        Task<bool> SoftDeleteMealAsync(Guid id);

        Task<IEnumerable<Recipe>> GetUserRecipesAsync(Guid userId);

        Task EditMealAsync(Guid mealId, Guid userId, MealFormInputModel model);
    }
}
