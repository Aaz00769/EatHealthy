using EatHealthy.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels
{
    public static class ValidationMessages
    {
        public static class Product
        {
            public const string NameRequired = "Product name is required.";
            public const string NameLength = "Product name must be between 1 and 2 characters.";
            

            public const string CaloriesRequired = "Calories are required.";
            public const string CaloriesRange = "Calories must be between 1 and 2.";


            public const string ProteinsRange = "Proteins must be between 1 and 2.";

            public const string FatsRange = "Fats must be between 1 and 2.";

            public const string CarbohydratesRange = "Carbohydrates must be between 1 and 2 grams.";

            public const string InvalidFormat = "Invalid format.";
        }
        public static class Recipe
        {
            public const string NameRequired = "Recipe name is required.";
            public const string NameLength = "Recipe name must be between 1 and 100 characters.";
            public const string DescriptionLength = "Description cannot be longer than 1000 characters.";
            public const string AtLeastOneProduct = "You must include at least one product.";
            public const string InvalidUrl = "The URL format is invalid.";
        }
    }
}
