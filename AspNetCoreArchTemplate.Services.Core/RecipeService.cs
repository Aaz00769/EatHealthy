

namespace EatHealthy.Services.Core
{
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data.Models;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Recipe;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IProductRepository _productRepository;



        public RecipeService(IRecipeRepository rcontext, IProductRepository productRepository)
        {
            _recipeRepository = rcontext;
            _productRepository = productRepository;
        }

        //Returns all the publicated recepies by a user
        public async Task<IEnumerable<RecipeViewModel>> GetAllPublicatedRecipesAsync()
        {

            var recipes = await _recipeRepository.GetAllPublicWithProductsAsync();
            return MapToViewModel(recipes);
        }

        //Shows a specific recipe that is owned by a user no matter if its public or not
        public async Task<IEnumerable<RecipeViewModel>> GetUserRecipesAsync(Guid userId)
        {
            var recipes = await _recipeRepository.GetUserRecipesAsync(userId);
            return MapToViewModel(recipes.Where(r => !r.IsDeleted));
        }

        //Addes a Recepie to the users collection of recepies 
        public async Task AddRecipeAsync(Guid userId,RecipeFormInputModel inputModel)
        {

            await ValidateRecipeProducts(inputModel.SelectedProducts);

            var newRecipe = new Recipe
            {
                CreatedByUserId = userId,
                Name = inputModel.Name,
                ImageUrl = inputModel.ImageUrl,
                Description = inputModel.Description,
                RecipeProducts = MapToRecipeProducts(inputModel.SelectedProducts)
            };

            await _recipeRepository.AddAsync(newRecipe);
            await _recipeRepository.SaveChangesAsync();
        }


        public async Task EditRecipeAsync(Guid userId, RecipeFormInputModel model)
        {

            var recipe = await _recipeRepository.GetByIdWithProductsAsync(userId,
                model.RecipeId,
                trackChanges: true
                             ) ?? throw new InvalidOperationException("Recipe not found.");

            if ( recipe.CreatedByUserId != userId || recipe.IsDeleted)
                throw new InvalidOperationException("Recipe not found.");

            await ValidateRecipeProducts(model.SelectedProducts);

            recipe.Name = model.Name;
            recipe.Description = model.Description;
            recipe.ImageUrl = model.ImageUrl;
            recipe.ModifiedOn = DateTime.UtcNow;

            await _recipeRepository.RemoveAllProductsFromRecipeAsync(recipe.Id, userId);

        
            foreach (var item in model.SelectedProducts.Where(p => p != null))
            {
                await _recipeRepository.AddProductToRecipeAsync(
                    recipeId: recipe.Id,
                    productId: item.ProductId,
                    quantity: item.Quantity,
                    grams: item.Grams
                );
            }

          
            await _recipeRepository.UpdateAsync(recipe);
            await _recipeRepository.SaveChangesAsync();
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
            var recipe = await _recipeRepository.GetByIdWithProductsAsync(userId, id,trackChanges: false);
            return recipe == null ? null : MapToFormModel(recipe);
        }

        private async Task ValidateRecipeProducts(IEnumerable<RecipeProductFormInputModel> products)
        {
            var productIds = products.Select(p => p.ProductId).Distinct().ToList();

            // CRITICAL FIX: Add soft delete check
            var activeProductIds = await _productRepository.All()
                .Where(p => productIds.Contains(p.Id) && !p.IsDeleted)
                .Select(p => p.Id)
                .ToListAsync();

            var missingIds = productIds.Except(activeProductIds).ToList();
            if (missingIds.Any())
            {
                throw new InvalidOperationException(
                    $"Invalid or deleted products: {string.Join(", ", missingIds)}");
            }
        }

        private List<RecipeProduct> MapToRecipeProducts( IEnumerable<RecipeProductFormInputModel> inputModels)
        {
            return inputModels.Select(rp => new RecipeProduct
            {
                ProductId = rp.ProductId,
                Quantity = rp.Quantity,
                Grams = rp.Grams
            }).ToList();
        }

        private IEnumerable<RecipeViewModel> MapToViewModel(IEnumerable<Recipe> recipes)
        {
            return recipes.Select(r => new RecipeViewModel
            {
                Id = r.Id,
                Name = r.Name,
                // FIX: Handle possible null Calories
                TotalCalories = r.RecipeProducts
                    .Sum(rp => (rp.Product?.Calories ?? 0) * rp.Quantity)
            });
        }

        private RecipeFormInputModel MapToFormModel(Recipe recipe)
        {
            return new RecipeFormInputModel
            {
                RecipeId = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                SelectedProducts = recipe.RecipeProducts
                    .Where(rp => rp.Product != null && !rp.Product.IsDeleted) // Security fix
                    .Select(rp => new RecipeProductFormInputModel
                    {
                        ProductId = rp.ProductId,
                        ProductName = rp.Product?.Name ?? "Deleted Product",
                        Quantity = rp.Quantity
                    }).ToList()
            };
        }
        public async Task<IEnumerable<RecipeViewModel>> GetRecipesByIdsAsync(IEnumerable<Guid> recipeIds)
        {
            var distinctIds = recipeIds.Distinct().ToList();
            if (!distinctIds.Any())
                return Enumerable.Empty<RecipeViewModel>();

            var recipes = await _recipeRepository.All()
                .Where(r => distinctIds.Contains(r.Id) && !r.IsDeleted)
                .Include(r => r.RecipeProducts)
                    .ThenInclude(rp => rp.Product)
                .AsNoTracking()
                .ToListAsync();

            return MapToViewModel(recipes);
        }
    }
}

