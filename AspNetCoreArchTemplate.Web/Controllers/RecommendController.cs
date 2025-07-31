using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Day;
using EatHealthy.Web.ViewModels.Meal;
using EatHealthy.Web.ViewModels.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EatHealthy.Web.Controllers
{
    [Authorize]
    public class RecommendController : Controller
    {
        private readonly IRecommendService _recommendService;
        private readonly IProfileService _profileService;

        public RecommendController(
            IRecommendService recommendService,
            IProfileService profileService)
        {
            _recommendService = recommendService;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Days()
        {
            var userId = GetCurrentUserId();
            var profile = await _profileService.GetUserProfileAsync(userId);

            if (profile == null)
            {
                return RedirectToAction("Setup", "Profiles");
            }

            var days = await _recommendService.RecommendDaysAsync(userId);
            return View(days);
        }

        [HttpGet]
        public async Task<IActionResult> Meals()
        {
            var userId = GetCurrentUserId();
            var profile = await _profileService.GetUserProfileAsync(userId);

            if (profile == null)
            {
                return RedirectToAction("Setup", "Profiles");
            }

            var meals = await _recommendService.RecommendMealsAsync(userId);
            return View(meals);
        }

        [HttpGet]
        public async Task<IActionResult> Recipes()
        {
            var userId = GetCurrentUserId();
            var profile = await _profileService.GetUserProfileAsync(userId);

            if (profile == null)
            {
                return RedirectToAction("Setup", "Profiles");
            }

            var recipes = await _recommendService.RecommendRecipesAsync(userId);
            return View(recipes);
        }

        private Guid GetCurrentUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }
    }
}