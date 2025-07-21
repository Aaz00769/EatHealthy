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
    [Comment("Product")]
    public class Product
    {
        [Comment("Product ID")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Product name")]
        public string Name { get; set; } = null!;

        [Comment("Calories per 100g")]
        public int Calories { get; set; }

        [Comment("Proteins per 100g (g)")]
        public int? Proteins { get; set; }

        [Comment("Fats per 100g (g)")]
        public int? Fats { get; set; }

        [Comment("Carbohydrates per 100g (g)")]
        public int? Carbohydrates { get; set; }

        [Comment("Standard serving size in grams")]
        public int? ServingSizeGrams { get; set; }

        [Comment("Used to check if itme is Soft Delited")]
        public bool IsDeleted {  get; set; } = false;

        public ICollection<RecipeProduct> RecipeProducts { get; set; } = new HashSet<RecipeProduct>();

    }
}
