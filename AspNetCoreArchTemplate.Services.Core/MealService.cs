namespace EatHealthy.Services.Core
{
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data.Models;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Meal;
    using EatHealthy.Web.ViewModels.Recipe;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IRecipeRepository _recipeRepository;

        public MealService(
            IMealRepository mealRepository,
            IRecipeRepository recipeRepository)
        {
            _mealRepository = mealRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task CreateMealAsync(Guid userId, MealFormInputModel model)
        {
            await ValidateRecipes(model.SelectedRecipeIds);

            var newMeal = new Meal
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CreatedByUserId = userId,
                Note = model.Note,
                MealRecipes = model.SelectedRecipeIds.Select(recipeId => new MealRecipe
                {
                    RecipeId = recipeId
                }).ToList()
            };

            await _mealRepository.AddAsync(newMeal);
            await _mealRepository.SaveChangesAsync();
        }

        public async Task EditMealAsync(Guid mealId, Guid userId, MealFormInputModel model)
        {
            var meal = await _mealRepository.GetByIdWithRecipesAsync(mealId, trackChanges: true);
            if (meal == null || meal.IsDeleted || meal.CreatedByUserId != userId)
                throw new InvalidOperationException("Meal not found or access denied");

            await ValidateRecipes(model.SelectedRecipeIds);

            meal.Name = model.Name;
            meal.Note = model.Note;

            // Update recipes
            var existingRecipeIds = meal.MealRecipes.Select(mr => mr.RecipeId).ToList();
            var recipesToRemove = existingRecipeIds.Except(model.SelectedRecipeIds).ToList();
            var recipesToAdd = model.SelectedRecipeIds.Except(existingRecipeIds).ToList();

            foreach (var recipeId in recipesToRemove)
            {
                await _mealRepository.RemoveRecipeFromMealAsync(mealId, recipeId);
            }

            // Add new recipes
            foreach (var recipeId in recipesToAdd)
            {
                await _mealRepository.AddRecipeToMealAsync(new MealRecipe
                {
                    MealId = mealId,
                    RecipeId = recipeId
                });
            }

            await _mealRepository.UpdateAsync(meal);
            await _mealRepository.SaveChangesAsync();
        }
        public async Task AddRecipeToMealAsync(Guid mealId, Guid recipeId)
        {
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);
            if (recipe == null || recipe.IsDeleted)
                throw new InvalidOperationException("Invalid recipe");

            var mealRecipe = new MealRecipe
            {
                MealId = mealId,
                RecipeId = recipeId
            };

            await _mealRepository.AddRecipeToMealAsync(mealRecipe);
        }

        public async Task<MealViewModel?> GetMealByIdAsync(Guid id)
        {
            var meal = await _mealRepository.GetByIdWithRecipesAsync(id, trackChanges: false);
            return meal == null ? null : MapToViewModel(meal);
        }

        public async Task<IEnumerable<Recipe>> GetUserRecipesAsync(Guid userId)
        {
            return await _recipeRepository.GetUserRecipesAsync(userId);
        }

        public async Task<IEnumerable<MealViewModel>> GetUserMealsAsync(Guid userId)
        {
            var meals = await _mealRepository.GetUserMealsAsync(userId);
            return meals.Select(MapToViewModel);
        }

        public async Task<bool> SoftDeleteMealAsync(Guid id)
        {
            var meal = await _mealRepository.GetByIdAsync(id);
            if (meal == null || meal.IsDeleted) return false;

            meal.IsDeleted = true;
            await _mealRepository.UpdateAsync(meal);
            await _mealRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MealViewModel>> GetMealsByIdsAsync(IEnumerable<Guid> mealIds)
        {
            var distinctIds = mealIds.Distinct().ToList();
            if (!distinctIds.Any())
                return Enumerable.Empty<MealViewModel>();

            var meals = await _mealRepository.All()
                .Where(m => distinctIds.Contains(m.Id) && !m.IsDeleted)
                .Include(m => m.MealRecipes)
                    .ThenInclude(mr => mr.Recipe)
                        .ThenInclude(r => r.RecipeProducts)
                            .ThenInclude(rp => rp.Product)
                .AsNoTracking()
                .ToListAsync();

            return meals.Select(MapToViewModel);
        }
        //-----------------------------------------------------------------
        //Private methoods 
        private async Task ValidateRecipes(IEnumerable<Guid> recipeIds)
        {
            var distinctIds = recipeIds.Distinct().ToList();
            if (!distinctIds.Any()) return;

            var validCount = await _recipeRepository.All()
                .CountAsync(r => distinctIds.Contains(r.Id) && !r.IsDeleted);

            if (validCount != distinctIds.Count)
                throw new InvalidOperationException("One or more recipes are invalid");
        }

        private MealViewModel MapToViewModel(Meal meal)
        {
            return new MealViewModel
            {
                Id = meal.Id,
                Name = meal.Name,
                Note = meal.Note,
                TotalCalories = CalculateTotalCalories(meal.MealRecipes),
                RecipeCount = meal.MealRecipes.Count,
                RecipeIds = meal.MealRecipes.Select(mr => mr.RecipeId) 

            };
        }

        private int CalculateTotalCalories(IEnumerable<MealRecipe> mealRecipes)
        {
            return mealRecipes
                .Where(mr => mr.Recipe != null && !mr.Recipe.IsDeleted)
                .Sum(mr =>
                    mr.Recipe.RecipeProducts.Sum(rp =>
                        ((rp.Product?.Calories ?? 0) * rp.Quantity) )
                    
                );
        }

    }
}