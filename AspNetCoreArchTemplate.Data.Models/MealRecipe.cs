using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Models
{
    [Comment("Junction table linking Meals and Recipes")]
    public class MealRecipe
    {
        [Comment("Unique identifier for the junction record")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Foreign key to the related Meal")]
        public Guid MealId { get; set; }

        [Comment("Foreign key to the related Recipe")]
        public Guid RecipeId { get; set; }

        // Navigation properties
        public Meal Meal { get; set; } = null!;
        public Recipe Recipe { get; set; } = null!;
    }
}
