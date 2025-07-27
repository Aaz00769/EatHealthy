using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels.Meal
{
    public class MealViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Note { get; set; }
        public int TotalCalories { get; set; }
        public int RecipeCount { get; set; }

        public IEnumerable<Guid> RecipeIds { get; set; } = new List<Guid>();
    }
}
