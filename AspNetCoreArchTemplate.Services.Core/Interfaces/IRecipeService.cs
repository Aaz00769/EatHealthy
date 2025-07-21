

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
        Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync();
        Task<RecipeFormInputModel?> GetByIdAsync(Guid id);
        Task AddRecipeAsync(RecipeFormInputModel model);
        Task EditRecipeAsync(Guid id, RecipeFormInputModel model);
        Task<bool> SoftDeleteRecipeAsync(Guid id);
    }
}
