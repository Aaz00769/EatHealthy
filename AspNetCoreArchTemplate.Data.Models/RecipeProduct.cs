using EatHealthy.GCommon.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EatHealthy.Data.Models
{
    [Comment("Links a Product to a Recipe with a specific amount used")]
    public class RecipeProduct
    {
        [Comment("Unique identifier for the relation")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Foreign key to the related recipe")]
        public Guid RecipeId { get; set; }

        [Comment("Foreign key to the related product")]
        public Guid ProductId { get; set; }

        [Comment("Amount of the product used in this recipe (grams)")]
        public int Grams { get; set; }

        [Comment("Optional description (e.g., chopped, grilled, peeled)")]
        public string? Note { get; set; }

        [Comment("Times Product is used in Recepie")]
        public int Quantity { get; set; } = 1;

        // Navigation properties
        public Recipe Recipe { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}

