using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels
{
    public static class ValidationMassages
    {
        public static class Product
        {
            public const string NameRequired = "Product name is required.";
            public const string NameLength = "Product name must be between {1} and {2} characters.";

            public const string CaloriesRequired = "Calories are required.";
            public const string CaloriesRange = "Calories must be between {1} and {2}.";

            public const string InvalidFormat = "Invalid format.";
        }
    }
}
