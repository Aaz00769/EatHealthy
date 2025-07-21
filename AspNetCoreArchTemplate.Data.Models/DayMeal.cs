using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EatHealthy.Data.Models
{
    [Comment("Junction table connecting Days and Meals")]
    public class DayMeal
    {
        [Comment("Unique identifier for the DayMeal record")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Foreign key to the Day")]
        public Guid DayId { get; set; }

        [Comment("Foreign key to the Meal")]
        public Guid MealId { get; set; }

        [Comment("Order of the meal within the day (e.g., 1 = breakfast, 2 = lunch)")]
        public int Order { get; set; }

        // Navigation
        public Day Day { get; set; } = null!;
        public Meal Meal { get; set; } = null!;
    }
}
