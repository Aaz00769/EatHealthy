using AspNetCoreArchTemplate.Data.Repository;
using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data.Models;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Day;
using EatHealthy.Web.ViewModels.Meal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Services.Core
{
    public class DayService : IDayService
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMealService _mealService;

        public DayService(IDayRepository dayRepository, IMealService mealService)
        {
            _dayRepository = dayRepository;
            _mealService = mealService;
        }

        public async Task CreateDayAsync(Guid userId, DayFormInputModel model)
        {
            await ValidateMeals(model.SelectedMealIds);

            var newDay = new Day
            {
                Id = Guid.NewGuid(),
                Date = model.Date,
                CreatedByUserId = userId,
                Note = model.Note,
                DayMeals = model.SelectedMealIds.Select(mealId => new DayMeal
                {
                    MealId = mealId
                }).ToList()
            };

            await _dayRepository.AddAsync(newDay);
            await _dayRepository.SaveChangesAsync();
        }

        public async Task EditDayAsync(Guid dayId, Guid userId, DayFormInputModel model)
        {
            var day = await _dayRepository.GetByIdWithMealsAsync(dayId, trackChanges: true);
            if (day == null || day.IsDeleted || day.CreatedByUserId != userId)
                throw new InvalidOperationException("Day not found or access denied");

            await ValidateMeals(model.SelectedMealIds);

            day.Date = model.Date;
            day.Note = model.Note;

            var existingMealIds = day.DayMeals.Select(dm => dm.MealId).ToList();
            var mealsToRemove = existingMealIds.Except(model.SelectedMealIds).ToList();
            var mealsToAdd = model.SelectedMealIds.Except(existingMealIds).ToList();

            foreach (var mealId in mealsToRemove)
            {
                await _dayRepository.RemoveMealFromDayAsync(dayId, mealId);
            }

            foreach (var mealId in mealsToAdd)
            {
                await _dayRepository.AddMealToDayAsync(new DayMeal
                {
                    DayId = dayId,
                    MealId = mealId
                });
            }

            await _dayRepository.UpdateAsync(day);
            await _dayRepository.SaveChangesAsync();
        }

        public async Task<MealViewmodel?> GetDayByIdAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdWithMealsAsync(id, trackChanges: false);
            return day == null ? null : MapToViewModel(day);
        }

        public async Task<IEnumerable<MealViewmodel>> GetUserDaysAsync(Guid userId)
        {
            var days = await _dayRepository.GetUserDaysAsync(userId);
            return days.Select(MapToViewModel);
        }

        public async Task<bool> SoftDeleteDayAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdAsync(id);
            if (day == null || day.IsDeleted) return false;

            day.IsDeleted = true;
            await _dayRepository.UpdateAsync(day);
            await _dayRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreDayAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdAsync(id);
            if (day == null || !day.IsDeleted) return false;

            day.IsDeleted = false;
            await _dayRepository.UpdateAsync(day);
            await _dayRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HardDeleteDayAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdAsync(id);
            if (day == null) return false;

            await _dayRepository.DeleteAsync(day);
            await _dayRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MealViewmodel>> GetAllDeletedDaysAsync(Guid userId)
        {
            var days = await _dayRepository.GetAllDeletedAsync(userId);
            return days.Select(MapToViewModel);
        }



        private async Task ValidateMeals(IEnumerable<Guid> mealIds)
        {
            var distinctIds = mealIds.Distinct().ToList();
            if (!distinctIds.Any()) return;

            var validCount = await _mealService.GetMealsByIdsAsync(distinctIds)
                .ContinueWith(t => t.Result.Count());

            if (validCount != distinctIds.Count)
                throw new InvalidOperationException("One or more meals are invalid");
        }

        private MealViewmodel MapToViewModel(Day day)
        {
            return new MealViewmodel
            {
                Id = day.Id,
                Date = day.Date,
                Note = day.Note,
                TotalCalories = CalculateTotalCalories(day.DayMeals),
                MealCount = day.DayMeals.Count,
                MealIds = day.DayMeals.Select(dm => dm.MealId)
            };
        }

        private int CalculateTotalCalories(IEnumerable<DayMeal> dayMeals)
        {
            return dayMeals
               .Where(dm => dm.Meal != null && !dm.Meal.IsDeleted)
                    .Sum(dm =>
                           dm.Meal.MealRecipes.Sum(mr =>
                           mr.Recipe?.RecipeProducts.Sum(rp =>
                          (rp.Product?.Calories ?? 0) * rp.Quantity) ?? 0)
                     );
        }
    }
}
