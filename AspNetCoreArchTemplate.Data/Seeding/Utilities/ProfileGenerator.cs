using Bogus;
using EatHealthy.Data.Common;
using EatHealthy.Data.Models;
using System;

namespace EatHealthy.Seeding.Utilities
{
    public class ProfileGenerator
    {
        private readonly Faker _faker;

        public ProfileGenerator()
        {
            _faker = new Faker();
        }

        public UserProfile GenerateProfile(Guid userId)
        {
            // Generate profile values first
            int age = _faker.Random.Int(18, 65);
            int height = _faker.Random.Int(150, 200);
            int weight = _faker.Random.Int(50, 120);
            var gender = (Gender)_faker.Random.Int(0, 2);
            var activityLevel = (ActivityLevel)_faker.Random.Int(0, 4);
            var goal = (GoalType)_faker.Random.Int(0, 2);
            int targetWeight = _faker.Random.Int(50, 100);

            // Calculate calories using generated values
            int dailyCalories = CalculateDailyCalorieTarget(
                gender, weight, height, age, activityLevel, goal);

            return new UserProfile
            {
                UserId = userId,
                Age = age,
                Height = height,
                Weight = weight,
                Gender = gender,
                ActivityLevel = activityLevel,
                Goal = goal,
                TargetWeight = targetWeight,
                DailyCalorieTarget = dailyCalories,  // Set the calculated value
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
        private int CalculateDailyCalorieTarget(Gender gender, int weight,int height,int age, ActivityLevel activityLevel, GoalType goalType)
        {
            // Mifflin-St Jeor Equation
            decimal bmr = gender switch
            {
                Gender.Male=> (10 * weight) + (6.25m * height) - (5 * age) + 5,
                Gender.Female => (10 * weight) + (6.25m * height) - (5 * age) - 161,
                _ => (10 * weight) + (6.25m * height) - (5 * age) // Average
            };

            decimal activityFactor = activityLevel switch
            {
                ActivityLevel.Sedentary => 1.2m,
                ActivityLevel.LightlyActive => 1.375m,
                ActivityLevel.ModeratelyActive => 1.55m,
                ActivityLevel.VeryActive => 1.725m,
                ActivityLevel.ExtremelyActive => 1.9m,
                _ => 1.2m
            };

            decimal tdee = bmr * activityFactor;

            // Adjust based on goal
            decimal goalFactor = goalType switch
            {
                GoalType.WeightLoss => 0.85m, // 15% deficit
                GoalType.WeightGain => 1.15m, // 15% surplus
                GoalType.MuscleBuilding => 1.10m, // 10% surplus
                _ => 1.0m // Maintenance
            };

            return (int)(tdee * goalFactor);
        }
    }
}