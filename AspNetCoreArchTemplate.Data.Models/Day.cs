using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Models
{
    [Comment("A day that contains multiple meals for a user")]
    public class Day
    {
        [Comment("Unique identifier for the day")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Optional description (e.g., chopped, grilled, peeled)")]
        public string? Note { get; set; }

        [Comment("Date this plan is for (e.g., 2025-07-21)")]
        public DateTime Date { get; set; }

        [Comment("User that owns this day plan")]
        public Guid UserId { get; set; }

        [Comment("Whether the user has marked this day as completed")]
        public bool IsCompleted { get; set; } = false;

        [Comment("All meals planned for this day")]
        public ICollection<DayMeal> DayMeals { get; set; } = new List<DayMeal>();

    }
}
