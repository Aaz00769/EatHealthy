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
    [Comment("Links a Product to a Recipe with a specific amount")]
    public class RecipeProduct
    {
        [Comment("Primary Key")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Foreign Key to Recipe")]
        public Guid RecipeId { get; set; }

        [Comment("Foreign Key to Product")]
        public Guid ProductId { get; set; }

        [Comment("Amount of the product in grams")]
        public int Grams { get; set; }

        [Comment("Optional note about the product (e.g., 'chopped', 'grilled')")]
        public string? Note { get; set; }

        // Navigation
        public Recipe Recipe { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
