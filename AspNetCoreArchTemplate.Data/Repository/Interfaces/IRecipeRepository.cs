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
        Task RemoveAllProductsFromRecipeAsync(Guid recipeId, Guid userId);

        Task<Recipe?> GetByIdWithProductsAsync(Guid userId, Guid id, bool trackChanges = false);
        Task AddProductToRecipeAsync(Guid recipeId, Guid productId, int quantity, int? grams);


        Task UpdateRecipeAsync(Recipe Recipe);
        Task<IEnumerable<Recipe>> GetByIdsAsync(IEnumerable<Guid> ids);
    }
}
