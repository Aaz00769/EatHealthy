using EatHealthy.Web.ViewModels.Day;
using EatHealthy.Web.ViewModels.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Services.Core.Interfaces
{
    public interface IDayService
    {
        Task CreateDayAsync(Guid userId, DayFormInputModel model);
        Task EditDayAsync(Guid dayId, Guid userId, DayFormInputModel model);
        Task<MealViewmodel?> GetDayByIdAsync(Guid id);
        Task<IEnumerable<MealViewmodel>> GetUserDaysAsync(Guid userId);
        Task<bool> SoftDeleteDayAsync(Guid id);
        Task<bool> RestoreDayAsync(Guid id);
        Task<bool> HardDeleteDayAsync(Guid id);
        Task<IEnumerable<MealViewmodel>> GetAllDeletedDaysAsync(Guid userId);
    }
}
