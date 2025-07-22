

namespace AspNetCoreArchTemplate.Data.Repository
{
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data;
    using EatHealthy.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class RecipeRepository : BaseRepository<Recipe, Guid>, IRecipeRepository
    {
        public RecipeRepository(EatHealthyDbContext context) 
            : base(context)
        {



        }
        public async Task<Recipe?> GetDetailedByIdAsync(Guid id)
        {
            return await this.All()
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }
        public async Task<Recipe?> GetByIdWithProductsAsync(Guid id)
        {
            return await this.All()
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }
        public async Task<IEnumerable<Recipe>> GetAllWithProductsAsync()
        {
            return await this.AllAsNoTracking()
                .Where(r => !r.IsDeleted)
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .ToListAsync();
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await this.AddAsync(recipe);
            await this.SaveChangesAsync();
        }

        public async Task EditRecipeAsync(Recipe recipe)
        {
            this.UpdateAsync(recipe);      // synchronous
            await this.SaveChangesAsync(); // async save
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            var recipe = await this.GetByIdAsync(id);
            if (recipe == null) return false;

            recipe.IsDeleted = true;
            await this.SaveChangesAsync();
            return true;
        }
    }
}
