using EatHealthy.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static EatHealthy.Web.ViewModels.ValidationMessages.Recipe;

namespace EatHealthy.Web.ViewModels.Recipe
{
    public class RecipeFormInputModel
    {
        public Guid RecipeId { get; set; }

        [Required(ErrorMessage = NameRequired)]
        [StringLength(100, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [Url(ErrorMessage = InvalidUrl)]
        public string? ImageUrl { get; set; }

        [StringLength(1000, ErrorMessage = DescriptionLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = AtLeastOneProduct)]
        [MinLength(1, ErrorMessage = AtLeastOneProduct)]
        public List<RecipeProductFormInputModel?> SelectedProducts { get; set; } = new();

        public List<ProductViewModel?> AvailableProducts { get; set; } = new();
    }
}
