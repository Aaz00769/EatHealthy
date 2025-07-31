using Bogus;
using EatHealthy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatHealthy.Seeding.Utilities
{
    public class DayGenerator
    {
        private readonly Faker _faker;

        public DayGenerator(List<Meal> meals)
        {
            _faker = new Faker();
        }

        public List<Day> GenerateDays(Guid userId, DateTime startDate, int count, List<Meal> meals)
        {
            var days = new List<Day>();

            for (int i = 0; i < count; i++)
            {
                days.Add(new Day
                {
                    CreatedByUserId = userId, // FIXED: Use actual user ID
                    Date = startDate.AddDays(i),
                    Note = $"Day {i + 1} of healthy eating",
                    IsDeleted = false,
                    DayMeals = GenerateDayMeals(meals, 1, 3)  // 1-3 meals per day
                });
            }

            return days;
        }

        private List<DayMeal> GenerateDayMeals(List<Meal> meals, int min, int max)
        {
            var count = _faker.Random.Int(min, max);
            var selectedMeals = _faker.PickRandom(meals, count);

            return selectedMeals.Select(m => new DayMeal
            {
                MealId = m.Id
            }).ToList();
        }
    }
}