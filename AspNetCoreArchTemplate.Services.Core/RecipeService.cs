

namespace EatHealthy.Services.Core
{
    using AspNetCoreArchTemplate.Data.Repository;
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data;
    using  EatHealthy.Data.Models;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Product;
    using EatHealthy.Web.ViewModels.Recipe;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static EatHealthy.Data.Common.EntityConsts;
    using static EatHealthy.Web.ViewModels.ValidationMessages;

            

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly EatHealthyDbContext _contexts;



        public RecipeService(IRecipeRepository rcontext, EatHealthyDbContext contexts)
        {
            _recipeRepository = rcontext;
            _contexts = contexts;
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

            return recipes
            .Where(r => !r.IsDeleted)
            .Select(r => new RecipeViewModel
            {
                Id = r.Id,
                Name = r.Name,
                TotalCalories = r.RecipeProducts.Sum(rp => rp.Product.Calories * rp.Quantity)
            });
        }
        //Addes a Recepie to the users collection of recepies 
        public async Task AddRecipeAsync(Guid userId,RecipeFormInputModel inputModel)
        {

            
            var newRecipe = new Data.Models.Recipe
            {
                CreatedByUserId= userId,
                Id = Guid.NewGuid(),
                Name = inputModel.Name,
                ImageUrl = inputModel.ImageUrl,
                Description = inputModel.Description,
                RecipeProducts = inputModel.SelectedProducts.Select(rp => new Data.Models.RecipeProduct
                {
                    ProductId = rp.ProductId,
                    Quantity = rp.Quantity
                }).ToList()
            };

            
            await _recipeRepository.AddRecipeAsync(newRecipe);
        }


        public async Task EditRecipeAsync(Guid userId, RecipeFormInputModel model)
        {
            // 1. Get existing recipe WITHOUT products
            var recipe = await _recipeRepository.GetByIdAsync(model.RecipeId);
            if (recipe == null || recipe.CreatedByUserId != userId || recipe.IsDeleted)
                throw new InvalidOperationException("Recipe not found.");

            // 2. Update scalar properties
            recipe.Name = model.Name;
            recipe.Description = model.Description;
            recipe.ModifiedOn = DateTime.UtcNow;

            // 3. Completely replace products
            await _recipeRepository.RemoveAllProductsFromRecipeAsync(recipe.Id, userId);

            // 4. Add new products
            foreach (var item in model.SelectedProducts.Where(p => p != null))
            {
                await _recipeRepository.AddProductToRecipeAsync(
                    recipeId: recipe.Id,
                    productId: item.ProductId,
                    quantity: item.Quantity,
                    grams: item.Grams
                );
            }

            // 5. Update recipe
            await _recipeRepository.UpdateAsync(recipe);
            await _recipeRepository.SaveChangesAsync();
        }
        public async Task<RecipeFormInputModel?> GetForEditByIdasync(Guid id)
        {
            return await _contexts.Recipes
                .Where(r => r.Id == id)
                .Select(r => new RecipeFormInputModel()
                {
                    RecipeId = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    SelectedProducts = r.RecipeProducts.Select(rp => new RecipeProductFormInputModel
                    {
                        ProductId = rp.ProductId,
                        ProductName = rp.Product.Name,
                        Quantity = rp.Quantity
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        //Soft delete a recepie
        public async Task<bool> SoftDeleteRecipeAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null || recipe.IsDeleted)
                return false;

            recipe.IsDeleted = true;
            recipe.ModifiedOn = DateTime.UtcNow;

            await _recipeRepository.UpdateAsync(recipe);
            await _recipeRepository.SaveChangesAsync();
            return true;
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
                    ProductName = rp.Product.Name,
                    Quantity = rp.Quantity
                }).ToList()
            };
        }


    }
}
