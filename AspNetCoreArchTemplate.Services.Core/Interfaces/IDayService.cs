using EatHealthy.Web.ViewModels.Day;
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
        Task AddMealToDayAsync(Guid dayId, Guid mealId);
        Task RemoveMealFromDayAsync(Guid dayMealId);
        Task<DayViewModel?> GetDayByIdAsync(Guid id);
        Task<IEnumerable<DayViewModel>> GetUserDaysAsync(Guid userId);
        Task<bool> SoftDeleteDayAsync(Guid id);
    }
}
