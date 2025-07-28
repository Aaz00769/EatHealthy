using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Day;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EatHealthy.Web.Controllers
{
    [Authorize]
    public class DayController : Controller
    {
        private readonly IDayService _dayService;
        private readonly IMealService _mealService;

        public DayController(IDayService dayService, IMealService mealService)
        {
            _dayService = dayService;
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var meals = await _mealService.GetUserMealsAsync(userId);

            var model = new DayFormInputModel
            {
                SelectedMealIds = new List<Guid>()
            };

            ViewBag.AvailableMeals = meals;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DayFormInputModel model)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (!ModelState.IsValid)
            {
                ViewBag.AvailableMeals = await _mealService.GetUserMealsAsync(userId);
                return View(model);
            }

            await _dayService.CreateDayAsync(userId, model);
            return RedirectToAction(nameof(MyDays));
        }

        [HttpGet]
        public async Task<IActionResult> MyDays()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var days = await _dayService.GetUserDaysAsync(userId);
            return View(days);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var day = await _dayService.GetDayByIdAsync(id);
            if (day == null) return NotFound();

            var mealIds = day.MealIds;
            var dayMeals = await _mealService.GetMealsByIdsAsync(mealIds);

            ViewBag.DayMeals = dayMeals;
            return View(day);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var day = await _dayService.GetDayByIdAsync(id);
            if (day == null) return NotFound();

            var meals = await _mealService.GetUserMealsAsync(userId);

            var model = new DayFormInputModel
            {
                Id = day.Id,
                Date = day.Date,
                Note = day.Note,
                SelectedMealIds = day.MealIds.ToList()
            };

            ViewBag.AvailableMeals = meals;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DayFormInputModel model)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (!ModelState.IsValid)
            {
                ViewBag.AvailableMeals = await _mealService.GetUserMealsAsync(userId);
                return View(model);
            }

            try
            {
                await _dayService.EditDayAsync(id, userId, model);
                return RedirectToAction(nameof(MyDays));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.AvailableMeals = await _mealService.GetUserMealsAsync(userId);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var success = await _dayService.SoftDeleteDayAsync(id);
            if (!success) return NotFound();
            return RedirectToAction(nameof(MyDays));
        }

        [HttpGet]
        public async Task<IActionResult> Deleted()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var deletedDays = await _dayService.GetAllDeletedDaysAsync(userId);
            return View(deletedDays);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Restore(Guid id)
        {
            var success = await _dayService.RestoreDayAsync(id);
            if (!success) return NotFound();
            return RedirectToAction(nameof(MyDays));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var success = await _dayService.HardDeleteDayAsync(id);
            if (!success) return NotFound();
            return RedirectToAction(nameof(Deleted));
        }
    }
}
