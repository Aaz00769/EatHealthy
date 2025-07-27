using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels.Meal
{
    public class MealFormInputModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Note { get; set; }

        public List<Guid> SelectedRecipeIds { get; set; } = new();
        public Guid Id { get; set; }
    }

}
