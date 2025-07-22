using EatHealthy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository.Interfaces
{
    public interface IMealRepository : IRepository<Meal, Guid>
    {
        // Add Meal-specific methods here if needed
        // For example:
        // Task<IEnumerable<Meal>> GetMealsByDayIdAsync(Guid dayId);
    }
}
