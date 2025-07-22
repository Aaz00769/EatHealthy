

namespace EatHealthy.Services.Core
{
    using AspNetCoreArchTemplate.Data.Repository;
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data;
    using EatHealthy.Data.Models;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Product;
    using EatHealthy.Web.ViewModels.Recipe;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository context)
        {
            _recipeRepository = context;
        }

        public async Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllWithProductsAsync();

            return recipes.Select(r => new RecipeViewModel
            {
                Id = r.Id,
                Name = r.Name,
                TotalCalories = r.RecipeProducts.Sum(rp => rp.Product.Calories * rp.Quantity)
            });
        }

        public async Task<RecipeFormInputModel?> GetByIdAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdWithProductsAsync(id);
            if (recipe == null) return null;

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
                    Quantity = rp.Quantity
                }).ToList()
            };

            await _recipeRepository.AddRecipeAsync(newRecipe);
        }

        public async Task EditRecipeAsync(Guid id, RecipeFormInputModel model)
        {
            var recipe = await _recipeRepository.GetByIdWithProductsAsync(id);


            if (recipe == null) throw new InvalidOperationException("Recipe not found.");

            recipe.Name = model.Name;
            recipe.RecipeProducts.Clear();
            recipe.RecipeProducts = model.SelectedProducts.Select(p => new RecipeProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            await _recipeRepository.EditRecipeAsync(recipe);
        }

        public async Task<bool> SoftDeleteRecipeAsync(Guid id)
        {
            return await _recipeRepository.SoftDeleteAsync(id);
        }
    }
}
