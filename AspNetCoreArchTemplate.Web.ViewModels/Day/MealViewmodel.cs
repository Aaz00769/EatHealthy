using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels.Day
{
    public class MealViewmodel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public double TotalCalories { get; set; }
        public int MealCount { get; set; }
        public IEnumerable<Guid> MealIds { get; set; } = new List<Guid>();
    }
}
