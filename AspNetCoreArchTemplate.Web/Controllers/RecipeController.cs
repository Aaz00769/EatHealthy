using EatHealthy.Data.Models;
using EatHealthy.Services.Core;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EatHealthy.Web.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeFacade _recipeFacade;
        
        public RecipeController(IRecipeFacade recipeFacade)
        {
            _recipeFacade=recipeFacade;
        }

        // GET: Recipe/CreateRecipe
        [HttpGet]
        public async Task<IActionResult> CreateRecipe()
        {
            var products = await _recipeFacade.GetAllProductAsync();

            var model = new RecipeFormInputModel
            {
                SelectedProducts = new List<RecipeProductFormInputModel>()
            };

            ViewBag.AvailableProducts = products;

            return View(model);
        }

        // POST: Recipe/CreateRecipe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRecipe(RecipeFormInputModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AvailableProducts = await _recipeFacade.GetAllProductAsync();
                return View(model);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _recipeFacade.CreateRecipeAsync(userId, model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> MyRecipes()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var recipes = await _recipeFacade.GetUserRecipesAsync(userId);

            return View(recipes);
        }


    }
}
