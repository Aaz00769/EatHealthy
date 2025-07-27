using EatHealthy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository.Interfaces
{
    public interface IMealRepository : IRepository<Meal, Guid>
    {
        Task<Meal?> GetByIdWithRecipesAsync(Guid id, bool trackChanges = false);
        Task<IEnumerable<Meal>> GetUserMealsAsync(Guid userId);
        Task AddRecipeToMealAsync(MealRecipe mealRecipe);
        Task RemoveRecipeFromMealAsync(Guid mealId, Guid recipeId);
    }
}

