

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
        //Returns all the publicated recepies by a user
        public async Task<IEnumerable<RecipeViewModel>> GetAllPublicatedRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllPublicWithProductsAsync();

            return recipes.Select(r => new RecipeViewModel
            {
                Id = r.Id,
                Name = r.Name,
                TotalCalories = r.RecipeProducts.Sum(rp => rp.Product.Calories * rp.Quantity)
            });
        }
        //Shows a specific recipe that is owned by a user no matter if its public or not
        public async Task<IEnumerable<RecipeViewModel>> GetUserRecipesAsync(Guid userId)
        {
            var recipes = await _recipeRepository.GetUserRecipesAsync(userId);

            return recipes.Select(r => new RecipeViewModel
            {
                Id = r.Id,
                Name = r.Name,
                TotalCalories = r.RecipeProducts.Sum(rp => rp.Product.Calories * rp.Quantity)
            });
        }
        //Addes a Recepie to the users collection of recepies 
        public async Task AddRecipeAsync(Guid userId,RecipeFormInputModel inputModel)
        {

            
            var newRecipe = new Recipe
            {
                CreatedByUserId= userId,
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

        //Save All changes to a recepie after a submit
        public async Task EditRecipeAsync(Guid userId, RecipeFormInputModel model)
        {
            if (model.RecipeId == null)
                throw new InvalidOperationException("Recipe ID is required.");
            var recipe = await _recipeRepository.GetByIdWithProductsAsync(userId,model.RecipeId.Value);


            if (recipe == null) throw new InvalidOperationException("Recipe not found.");
            
            recipe.Name = model.Name;
            recipe.RecipeProducts.Clear();
            await _recipeRepository.RemoveAllProductsFromRecipeAsync(model.RecipeId.Value);

            recipe.RecipeProducts = model.SelectedProducts.Select(p => new RecipeProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            await _recipeRepository.EditRecipeAsync(recipe);
        }
        //Soft delete a recepie
        public async Task<bool> SoftDeleteRecipeAsync(Guid id)
        {
            return await _recipeRepository.SoftDeleteAsync(id);
        }

        public async Task<RecipeFormInputModel?> ShowRecipeByIdAsync(Guid userId, Guid id)
        {
            var recipe = await _recipeRepository.GetByIdWithProductsAsync(userId, id);
            if (recipe == null) return null;

            return new RecipeFormInputModel
            {
                RecipeId = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                SelectedProducts = recipe.RecipeProducts.Select(rp => new RecipeProductFormInputModel
                {
                    ProductId = rp.ProductId,
                    Quantity = rp.Quantity
                }).ToList()
            };
        }


    }
}
