using System;

namespace EatHealthy.Web.ViewModels.Recipe
{
    public class RecipeProductFormInputModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;

        public int? Grams {  get; set; }
    }
}
