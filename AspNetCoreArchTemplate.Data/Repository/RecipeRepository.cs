

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
        //returns a list of all publicated Recepies
        public async Task<IEnumerable<Recipe>> GetAllPublicWithProductsAsync()
        {
            return await this.All()
                .Where(r => !r.IsDeleted && r.IsPublic)
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .ToListAsync();
        }
        public async Task<Recipe?> GetDetailedByIdAsync( Guid id)
        {
            return await this.All()
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }
        //returns a recepie witha all its products
        public async Task<IEnumerable<Recipe>> GetUserRecipesAsync(Guid userId)
        {
            return await this.All()
                .Where(r => r.CreatedByUserId == userId)
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                    .ToListAsync();
                
        }

        public async Task<Recipe?> GetByIdWithProductsAsync(Guid userId, Guid id)
        {
            return await this.All()
                .Where(r => r.CreatedByUserId == userId && r.Id == id && !r.IsDeleted)
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .FirstOrDefaultAsync();
        }

        //Adds a recepie 
        public async Task AddRecipeAsync(Recipe recipe)
        {
            await this.AddAsync(recipe);
            await this.SaveChangesAsync();

        }
        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            // This method should handle the update without RemoveAllProducts
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
        public async Task<Recipe?> GetByIdAsync(Guid id)
        {
            return await _context.Recipes.FindAsync(id);
        }
        public async Task EditRecipeAsync(Recipe recipe)
        {
            await this.UpdateAsync(recipe);      // synchronous
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
        //Remooves fully recepieProducts from a recepie
        public async Task RemoveAllProductsFromRecipeAsync(Guid recipeId, Guid userId)
        {
            var recipe = await _context.Recipes
               .Include(r => r.RecipeProducts)
               .FirstOrDefaultAsync(r => r.Id == recipeId && r.CreatedByUserId == userId && !r.IsDeleted);


            if (recipe == null)
                throw new ArgumentException("Recipe not found.");

            _context.RecipeProducts.RemoveRange(recipe.RecipeProducts);
            recipe.RecipeProducts.Clear(); 

            
        }

        
    }
}
