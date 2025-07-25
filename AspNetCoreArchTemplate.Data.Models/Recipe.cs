using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Models
{
    [Comment("User-created recipe made up of multiple products")]
    public class Recipe
    {
        [Comment("Unique identifier for the recipe")]
        public Guid Id { get; set; }

        [Comment("Name of the recipe (e.g., Chicken Stir Fry)")]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [Comment("Optional description or instructions for the recipe")]
        public string? Description { get; set; }

        [Comment("ID of the user who created this recipe")]
        public Guid CreatedByUserId { get; set; }
        public AppUser CreatedByUser { get; set; } 

        [Comment("Used to check if item is Soft Delited")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Whether the user has marked this recipe as public")]
        public bool IsPublic { get; set; } = false;

        [Comment("Whether an administrator has approved the recipe for public visibility")]
        public bool IsApprovedByAdmin { get; set; } = false;

        [Comment("Date and time when the recipe was created (UTC)")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Comment("Date and time when the recipe was last modified (nullable)")]
        public DateTime? ModifiedOn { get; set; }
        

        [Comment("List of products used in the recipe with their amounts")]
        public ICollection<RecipeProduct> RecipeProducts { get; set; } = new List<RecipeProduct>();

        public ICollection<MealRecipe> MealRecipes { get; set; } = new List<MealRecipe>();

    }
}
