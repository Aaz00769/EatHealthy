using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data.Models;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Day;
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
        private readonly IMealRepository _mealRepository;

        public DayService(
            IDayRepository dayRepository,
            IMealRepository mealRepository)
        {
            _dayRepository = dayRepository;
            _mealRepository = mealRepository;
        }

        public async Task CreateDayAsync(Guid userId, DayFormInputModel model)
        {
            await ValidateMeals(model.SelectedMealIds);

            var newDay = new Day
            {
                Date = model.Date,
                CreatedByUserId = userId,
                Note = model.Note,
                DayMeals = model.SelectedMealIds.Select(mealId => new DayMeal
                {
                    MealId = mealId,
                   
                }).ToList()
            };

            await _dayRepository.AddAsync(newDay);
            await _dayRepository.SaveChangesAsync();
        }

        public async Task AddMealToDayAsync(Guid dayId, Guid mealId)
        {
            var meal = await _mealRepository.GetByIdAsync(mealId);
            if (meal == null || meal.IsDeleted)
                throw new InvalidOperationException("Invalid meal");

            var dayMeal = new DayMeal
            {
                DayId = dayId,
                MealId = mealId,
               
            };

            await _dayRepository.AddMealToDayAsync(dayMeal);
        }

        public async Task RemoveMealFromDayAsync(Guid dayMealId)
        {
            await _dayRepository.RemoveMealFromDayAsync(dayMealId);
        }

        public async Task<DayViewModel?> GetDayByIdAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdWithMealsAsync(id, trackChanges: false);
            return day == null ? null : MapToViewModel(day);
        }

        public async Task<IEnumerable<DayViewModel>> GetUserDaysAsync(Guid userId)
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

        private async Task ValidateMeals(IEnumerable<Guid> mealIds)
        {
            var distinctIds = mealIds.Distinct().ToList();
            if (!distinctIds.Any()) return;

            var validCount = await _mealRepository.All()
                .CountAsync(m => distinctIds.Contains(m.Id) && !m.IsDeleted);

            if (validCount != distinctIds.Count)
                throw new InvalidOperationException("One or more meals are invalid");
        }

        private DayViewModel MapToViewModel(Day day)
        {
            return new DayViewModel
            {
                Id = day.Id,
                Date = day.Date,
                Note = day.Note,
                TotalCalories = CalculateTotalCalories(day.DayMeals),
            
            };
        }

        private int CalculateTotalCalories(IEnumerable<DayMeal> dayMeals)
        {
            return dayMeals.Sum(dm =>
                dm.Meal?.MealRecipes.Sum(mr =>
                    mr.Recipe?.RecipeProducts.Sum(rp =>
                        (rp.Product?.Calories ?? 0) * rp.Quantity) ?? 0) ?? 0);
        }
    }

}
