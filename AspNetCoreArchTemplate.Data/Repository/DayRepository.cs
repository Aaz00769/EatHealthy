using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data;
using EatHealthy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository
{
    public class DayRepository : BaseRepository<Day, Guid>, IDayRepository
    {
        public DayRepository(EatHealthyDbContext context) : base(context) { }

        public async Task<Day?> GetByIdWithMealsAsync(Guid id, bool trackChanges = false)
        {
            var query = _context.Days
                .Include(d => d.DayMeals)
                    .ThenInclude(dm => dm.Meal)
                .Where(d => d.Id == id);

            if (!trackChanges) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Day>> GetUserDaysAsync(Guid userId)
        {
            return await _context.Days
                .Where(d => d.CreatedByUserId == userId && !d.IsDeleted)
                .Include(d => d.DayMeals)
                    .ThenInclude(dm => dm.Meal)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddMealToDayAsync(DayMeal dayMeal)
        {
            var exists = await _context.DayMeals
                .AnyAsync(dm => dm.DayId == dayMeal.DayId && dm.MealId == dayMeal.MealId);

            if (!exists)
            {
                _context.DayMeals.Add(dayMeal);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveMealFromDayAsync(Guid dayId, Guid mealId)
        {
            var dayMeal = await _context.DayMeals
                .FirstOrDefaultAsync(dm => dm.DayId == dayId && dm.MealId == mealId);

            if (dayMeal != null)
            {
                _context.DayMeals.Remove(dayMeal);
                await SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Day>> GetAllDeletedAsync(Guid userId)
        {
            return await _context.Days
                .Where(d => d.CreatedByUserId == userId && d.IsDeleted)
                .Include(d => d.DayMeals)
                    .ThenInclude(dm => dm.Meal)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteAsync(Day day)
        {
            _context.Days.Remove(day);
            await SaveChangesAsync();
        }
    }
}
