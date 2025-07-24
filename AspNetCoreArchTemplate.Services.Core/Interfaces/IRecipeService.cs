

namespace EatHealthy.Services.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EatHealthy.Web.ViewModels.Recipe;
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeViewModel>> GetAllPublicatedRecipesAsync();
        Task<IEnumerable<RecipeViewModel>> GetUserRecipesAsync(Guid userId);

        Task<RecipeFormInputModel?> ShowRecipeByIdAsync(Guid userId, Guid id);
        Task AddRecipeAsync(Guid userId,RecipeFormInputModel model);
        Task EditRecipeAsync(Guid id, RecipeFormInputModel model);
        Task<bool> SoftDeleteRecipeAsync(Guid id);
    }
}
