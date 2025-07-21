using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels.Recipe
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<RecipeProductInputModel> SelectedProducts { get; set; } = new();

        public int TotalCalories { get; set; }

        public string? Description { get; set; }
    }
}
