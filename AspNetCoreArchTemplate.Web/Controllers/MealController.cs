using EatHealthy.Data.Models;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Meal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EatHealthy.Web.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealService _mealService;
        private readonly IRecipeService _recipeService;

        public MealController(
            IMealService mealService,
            IRecipeService recipeService)
        {
            _mealService = mealService;
            _recipeService = recipeService;
        }

        // GET: Meal/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var recipes = await _recipeService.GetUserRecipesAsync(userId);

            ViewBag.AvailableRecipes = recipes;
            return View(new MealFormInputModel());
        
        }

        // POST: Meal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MealFormInputModel model)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (!ModelState.IsValid)
            {
                ViewBag.AvailableRecipes = await _recipeService.GetUserRecipesAsync(userId);
                return View(model);
            }

            await _mealService.CreateMealAsync(userId, model);
            return RedirectToAction(nameof(MyMeals));
        }

        // GET: Meal/MyMeals
        [HttpGet]
        public async Task<IActionResult> MyMeals()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var meals = await _mealService.GetUserMealsAsync(userId);
            return View(meals);
        }

        // GET: Meal/Details/{id}

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var meal = await _mealService.GetMealByIdAsync(id);
            if (meal == null) return NotFound();

            // Get meal recipes details
            var mealRecipes = await _recipeService.GetRecipesByIdsAsync(meal.RecipeIds);

            ViewBag.MealRecipes = mealRecipes;
            return View(meal);
        }

        // GET: Meal/Edit/{id}
         [HttpGet]
         public async Task<IActionResult> Edit(Guid id)
         {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var meal = await _mealService.GetMealByIdAsync(id);
            if (meal == null) return NotFound();

            var recipes = await _recipeService.GetUserRecipesAsync(userId);

            var model = new MealFormInputModel
            {
                Id = meal.Id,
                Name = meal.Name,
                Note = meal.Note,
                SelectedRecipeIds = meal.RecipeIds.ToList()
            };

            ViewBag.AvailableRecipes = recipes;
            return View(model);
         }
         
        // POST: Meal/Edit/{id}
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(Guid id, MealFormInputModel model)
         {
             var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

             if (!ModelState.IsValid)
             {
                 ViewBag.AvailableRecipes = await _recipeService.GetUserRecipesAsync(userId);
                 return View(model);
             }

             try
             {
                 await _mealService.EditMealAsync(id, userId, model);
                 return RedirectToAction(nameof(MyMeals));
             }
             catch (InvalidOperationException ex)
             {
                 ModelState.AddModelError("", ex.Message);
                 ViewBag.AvailableRecipes = await _recipeService.GetUserRecipesAsync(userId);
                 return View(model);
             }
         }

        // POST: Meal/SoftDelete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var success = await _mealService.SoftDeleteMealAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(MyMeals));
        }

        
    }
}