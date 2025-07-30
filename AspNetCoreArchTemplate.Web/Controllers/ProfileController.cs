using EatHealthy.Data.Models;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EatHealthy.Web.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly UserManager<AppUser> _userManager;

        public ProfilesController(
            IProfileService profileService,
            UserManager<AppUser> userManager)
        {
            _profileService = profileService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Setup()
        {
            return View(new UserProfileModel());
        }

        [HttpPost]
        public async Task<IActionResult> Setup(UserProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _profileService.CreateOrUpdateProfileAsync(userId, model);

            // Update user profile completed status
            var user = await _userManager.GetUserAsync(User);
            user.ProfileCompleted = true;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var profile = await _profileService.GetUserProfileAsync(userId);

            if (profile == null)
            {
                return RedirectToAction("Setup");
            }

            var model = new UserProfileModel
            {
                Age = profile.Age,
                Height = profile.Height,
                Weight = profile.Weight,
                Gender = profile.Gender,
                ActivityLevel = profile.ActivityLevel,
                Goal = profile.Goal,
                TargetWeight = profile.TargetWeight
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _profileService.CreateOrUpdateProfileAsync(userId, model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Stats()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var profile = await _profileService.GetUserProfileAsync(userId);

            if (profile == null)
            {
                return RedirectToAction("Setup");
            }

            var model = new UserStatsViewModel
            {
                Age = profile.Age,
                Height = profile.Height,
                Weight = profile.Weight,
                TargetWeight = profile.TargetWeight,
                Gender = profile.Gender,
                ActivityLevel = profile.ActivityLevel,
                Goal = profile.Goal,
                DailyCalorieTarget = profile.DailyCalorieTarget,
                CreatedAt = profile.CreatedAt,
                UpdatedAt = profile.UpdatedAt
            };

            return View(model);
        }
    }
}
