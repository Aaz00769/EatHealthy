

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
    public class MealRepository : BaseRepository<Meal, Guid>, IMealRepository
    {
        public MealRepository(EatHealthyDbContext context) : base(context) { }

        public async Task<Meal?> GetByIdWithRecipesAsync(Guid id, bool trackChanges = false)
        {
            var query = _context.Meals
                 .Include(m => m.MealRecipes)
                   .ThenInclude(mr => mr.Recipe)
                      .ThenInclude(r => r.RecipeProducts)
                         .ThenInclude(rp => rp.Product)
                   .Where(m => m.Id == id);

            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Meal>> GetUserMealsAsync(Guid userId)
        {
            return await _context.Meals
                .Where(m => m.CreatedByUserId == userId && !m.IsDeleted)
                .Include(m => m.MealRecipes)
                    .ThenInclude(mr => mr.Recipe)
                        .ThenInclude(r => r.RecipeProducts)
                            .ThenInclude(rp => rp.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddRecipeToMealAsync(MealRecipe mealRecipe)
        {
            _context.MealRecipes.Add(mealRecipe);
            await SaveChangesAsync();
        }

        public async Task RemoveRecipeFromMealAsync(Guid mealId, Guid recipeId)
        {
            var mealRecipe = await _context.MealRecipes
                .FirstOrDefaultAsync(mr => mr.MealId == mealId && mr.RecipeId == recipeId);

            if (mealRecipe != null)
            {
                _context.MealRecipes.Remove(mealRecipe);
                await SaveChangesAsync();
            }
        }
       
        
    }
}
