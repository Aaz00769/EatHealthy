using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Models
{
    [Comment("A specific meal in a day (e.g., breakfast, lunch, dinner)")]
    public class Meal
    {
        [Comment("Unique identifier for the meal")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Name of the meal (e.g., Breakfast, Snack, Post-Workout)")]
        public string Name { get; set; }

        [Comment("ID of the user who created this meal")]
        public Guid CreatedByUserId { get; set; }
        public AppUser CreatedByUser { get; set; } = null!;

        [Comment("Optional note (e.g., mood, hunger level, etc.)")]
        public string? Note { get; set; }

        [Comment("Timestamp when the meal was consumed (optional)")]
        public DateTime? TimeEaten { get; set; }

        [Comment("List of recipes consumed in this meal")]
        public ICollection<MealRecipe> MealRecipes { get; set; } = new List<MealRecipe>();

        public ICollection<DayMeal> DayMeals { get; set; } = new List<DayMeal>();


    }
}
