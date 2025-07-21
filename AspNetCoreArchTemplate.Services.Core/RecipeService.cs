

namespace EatHealthy.Services.Core
{
    using EatHealthy.Data;
    using EatHealthy.Data.Models;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EatHealthy.Web.ViewModels.Recipe;
    using Microsoft.EntityFrameworkCore;

    public class RecipeService : IRecipeService
    {
        private readonly EatHealthyDbContext _context;

        public RecipeService(EatHealthyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync()
        {
            return await _context.Recipes
                .Where(r => !r.IsDeleted)
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .Select(r => new RecipeViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalCalories = r.RecipeProducts.Sum(rp => rp.Product.Calories * rp.Quantity)
                })
                .ToListAsync();
        }

        public async Task<RecipeFormInputModel?> GetByIdAsync(Guid id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.RecipeProducts)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (recipe == null) return null;

            return new RecipeFormInputModel
            {
                RecipeId = recipe.Id,
                Name = recipe.Name,
                SelectedProducts = recipe.RecipeProducts.Select(rp => new RecipeProductInputModel
                {
                    ProductId = rp.ProductId,
                    Quantity = rp.Quantity
                }).ToList()
            };
        }

        public async Task AddRecipeAsync(RecipeFormInputModel inputModel)
        {
            var newRecipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = inputModel.Name,
                ImageUrl = inputModel.ImageUrl,
                Description = inputModel.Description,
                RecipeProducts = inputModel.SelectedProducts.Select(rp => new RecipeProduct
                {
                    ProductId = rp.ProductId,
                    Quantity=rp.Quantity
                }).ToList()
            };

            await _context.Recipes.AddAsync(newRecipe);
            await _context.SaveChangesAsync();
        }

        public async Task EditRecipeAsync(Guid id, RecipeFormInputModel model)
        {
            var recipe = await _context.Recipes
                .Include(r => r.RecipeProducts)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (recipe == null) throw new InvalidOperationException("Recipe not found.");

            recipe.Name = model.Name;

            // Clear and re-add RecipeProducts
            recipe.RecipeProducts.Clear();
            recipe.RecipeProducts = model.SelectedProducts.Select(p => new RecipeProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteRecipeAsync(Guid id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return false;

            recipe.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
