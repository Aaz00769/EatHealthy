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
        Task<Recipe?> GetDetailedByIdAsync(Guid id);
        Task<Recipe?> GetByIdWithProductsAsync(Guid id);
        Task<IEnumerable<Recipe>> GetAllWithProductsAsync();
        Task AddRecipeAsync(Recipe recipe);
        Task EditRecipeAsync(Recipe recipe);
        Task<bool> SoftDeleteAsync(Guid id);

    }
}
