using Bogus;
using EatHealthy.Data.Models;
using System.Collections.Generic;

namespace EatHealthy.Seeding.Utilities
{
    public class ProductGenerator
    {
        public static List<Product> GenerateProducts(int count)
        {
            var productFaker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Calories, f => f.Random.Int(50, 500))
                .RuleFor(p => p.IsDeleted, false);

            return productFaker.Generate(count);
        }
    }
}