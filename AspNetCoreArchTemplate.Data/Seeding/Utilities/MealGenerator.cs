using Bogus;
using EatHealthy.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace EatHealthy.Seeding.Utilities
{
    public class MealGenerator
    {
        private readonly Faker _faker;

        public MealGenerator(List<Recipe> recipes)
        {
            _faker = new Faker();
        }

        public List<Meal> GenerateMeals(Guid userId, int count, List<Recipe> recipes)
        {
            var meals = new List<Meal>();

            for (int i = 0; i < count; i++)
            {
                meals.Add(new Meal
                {
                    CreatedByUserId = userId, 
                    Name = $"Meal {i + 1}",
                    IsDeleted = false,
                    Note = _faker.Lorem.Sentence(),
                    MealRecipes = GenerateMealRecipes(recipes, 1, 3) // 1-3 recipes per meal
                });
            }

            return meals;
        }

        private List<MealRecipe> GenerateMealRecipes(List<Recipe> recipes, int min, int max)
        {
            var count = _faker.Random.Int(min, max);
            var selectedRecipes = _faker.PickRandom(recipes, count);

            return selectedRecipes.Select(r => new MealRecipe
            {
                RecipeId = r.Id
            }).ToList();
        }
    }
}