using EatHealthy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository.Interfaces
{
    public interface IRecipeRepository:IRepository<Recipe,Guid>
    {
        Task<Recipe?> GetDetailedByIdAsync( Guid id);
        Task<IEnumerable<Recipe>> GetUserRecipesAsync(Guid userId);
        Task<IEnumerable<Recipe>> GetAllPublicWithProductsAsync();
        Task AddRecipeAsync(Recipe recipe);
        Task EditRecipeAsync(Recipe recipe);
        Task<bool> SoftDeleteAsync(Guid id);
        Task RemoveAllProductsFromRecipeAsync(Guid recipeId);

        Task<Recipe?> GetByIdWithProductsAsync(Guid userId, Guid id);
    }
}
