using Bogus;
using EatHealthy.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace EatHealthy.Seeding.Utilities
{
    public class RecipeGenerator
    {
        private readonly List<Product> _products;
        private readonly Faker _faker;

        public RecipeGenerator(List<Product> products)
        {
            _products = products;
            _faker = new Faker();
        }

        public List<Recipe> GenerateRecipes(Guid userId, int count, bool isPublic = false)
        {
            var recipes = new List<Recipe>();

            for (int i = 0; i < count; i++)
            {
                recipes.Add(new Recipe
                {
                    CreatedByUserId = userId, 
                    Name = _faker.Lorem.Word(),
                    Description = _faker.Lorem.Sentence(),
                    ImageUrl = _faker.Image.PicsumUrl(),
                    IsPublic = isPublic,
                    IsDeleted = false,
                    RecipeProducts = GenerateRecipeProducts(1, 5) // 1-5 products per recipe
                });
            }

            return recipes;
        }

        private List<RecipeProduct> GenerateRecipeProducts(int min, int max)
        {
            var count = _faker.Random.Int(min, max);
            var selectedProducts = _faker.PickRandom(_products, count);

            return selectedProducts.Select(p => new RecipeProduct
            {
                ProductId = p.Id,
                Quantity = (int)_faker.Random.Decimal(0.5m, 3),
                Grams = (int?)_faker.Random.Decimal(50, 300)
            }).ToList();
        }
    }
}
