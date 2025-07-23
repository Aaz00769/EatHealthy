using System;

namespace EatHealthy.Web.ViewModels.Recipe
{
    public class RecipeProductFormInputModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        
    }
}
