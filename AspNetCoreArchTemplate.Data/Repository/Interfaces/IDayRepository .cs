using EatHealthy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository.Interfaces
{
    public interface IDayRepository : IRepository<Day, Guid>
    {
        Task<Day?> GetByIdWithMealsAsync(Guid id, bool trackChanges = false);
        Task<IEnumerable<Day>> GetUserDaysAsync(Guid userId);
        Task AddMealToDayAsync(DayMeal dayMeal);
        Task RemoveMealFromDayAsync(Guid dayId, Guid mealId);
        Task<IEnumerable<Day>> GetAllDeletedAsync(Guid userId);
        Task DeleteAsync(Day day);
    }
}

