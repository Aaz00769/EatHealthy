using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data.Models;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Day;
using EatHealthy.Web.ViewModels.Meal;
using EatHealthy.Web.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EatHealthy.Data.Common.EntityConsts;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Day = EatHealthy.Data.Models.Day;
using Meal = EatHealthy.Data.Models.Meal;

namespace EatHealthy.Services.Core
{
    public class RecommendService : IRecommendService
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IProfileService _profileService;
        private readonly IMealService _mealService;
        private readonly IRecipeService _recipeService;
        private const double CalorieTolerance = 0.2; // 20% tolerance

        public RecommendService(
            IDayRepository dayRepository,
            IMealRepository mealRepository,
            IProfileService profileService,
            IMealService mealService,
            IRecipeService recipeService)
        {
            _dayRepository = dayRepository;
            _mealRepository = mealRepository;
            _profileService = profileService;
            _mealService = mealService;
            _recipeService = recipeService;
        }

        public async Task<IEnumerable<MealViewmodel>> RecommendDaysAsync(Guid userId)
        {
            var profile = await _profileService.GetUserProfileAsync(userId);
            if (profile?.DailyCalorieTarget == null)
                return Enumerable.Empty<MealViewmodel>();

            double dailyTarget = profile.DailyCalorieTarget;
           
            double upperBound = dailyTarget * (1 + CalorieTolerance);

            var days = await _dayRepository.GetUserDaysAsync(userId);
            var validDays = days;

            return validDays
                .Select(day => new {
                    Day = day,
                    TotalCalories = CalculateDayCalories(day)
                })
                .Where(x => 
                             x.TotalCalories <= upperBound)
                .Select(x => MapToDayViewModel(x.Day, x.TotalCalories))
                .ToList();
        }

        public async Task<IEnumerable<MealViewModel>> RecommendMealsAsync(Guid userId)
        {
            var profile = await _profileService.GetUserProfileAsync(userId);
            if (profile?.DailyCalorieTarget == null)
                return Enumerable.Empty<MealViewModel>();

            double mealTarget = profile.DailyCalorieTarget / 3.0; // 3 meals/day
            double lowerBound = mealTarget * (1 - CalorieTolerance);
            double upperBound = mealTarget * (1 + CalorieTolerance);

            var meals = await _mealRepository.GetUserMealsAsync(userId);
            var validMeals = meals.Where(m => !m.IsDeleted);

            return validMeals
                .Select(meal => new {
                    Meal = meal,
                    TotalCalories = CalculateMealCalories(meal)
                })
                .Where(x => x.TotalCalories >= lowerBound &&
                             x.TotalCalories <= upperBound)
                .Select(x => MapToMealViewModel(x.Meal, x.TotalCalories))
                .ToList();
        }

        public async Task<IEnumerable<RecipeViewModel>> RecommendRecipesAsync(Guid userId)
        {
            var profile = await _profileService.GetUserProfileAsync(userId);
            if (profile?.DailyCalorieTarget == null)
                return Enumerable.Empty<RecipeViewModel>();

            double recipeTarget = profile.DailyCalorieTarget / 6.0; // 2 recipes/meal * 3 meals
            double lowerBound = recipeTarget * (1 - CalorieTolerance);
            double upperBound = recipeTarget * (1 + CalorieTolerance);

            var recipes = await _recipeService.GetUserRecipesAsync(userId);

            return recipes
                .Where(r => r.TotalCalories >= lowerBound &&
                             r.TotalCalories <= upperBound)
                .ToList();
        }

        // Helper methods
        private int CalculateDayCalories(Day day)
        {
            return day.DayMeals
                .Where(dm => dm.Meal != null && !dm.Meal.IsDeleted)
                .Sum(dm => CalculateMealCalories(dm.Meal));
        }

        private int CalculateMealCalories(Meal meal)
        {
            return meal.MealRecipes
                .Where(mr => mr.Recipe != null && !mr.Recipe.IsDeleted)
                .Sum(mr => mr.Recipe.RecipeProducts
                    .Sum(rp => (rp.Product?.Calories ?? 0) * rp.Quantity));
        }

        private MealViewmodel MapToDayViewModel(Day day, double totalCalories)
        {
            return new MealViewmodel
            {
                Id = day.Id,
                Date = day.Date,
                Note = day.Note,
                TotalCalories = totalCalories,
                MealCount = day.DayMeals.Count,
                MealIds = day.DayMeals.Select(dm => dm.MealId)
            };
        }

        private MealViewModel MapToMealViewModel(Meal meal, double totalCalories)
        {
            return new MealViewModel
            {
                Id = meal.Id,
                Name = meal.Name,
                Note = meal.Note,
                TotalCalories = totalCalories,
                RecipeCount = meal.MealRecipes.Count,
                RecipeIds = meal.MealRecipes.Select(mr => mr.RecipeId)
            };
        }
    }
}
