using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data.Common;
using EatHealthy.Data.Models;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Profile;

namespace EatHealthy.Services.Core
{
    public class ProfileService : IProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public ProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task CreateOrUpdateProfileAsync(Guid userId, UserProfileModel model)
        {
            var profile = await _userProfileRepository.GetByUserIdAsync(userId);

            if (profile == null)
            {
                profile = new UserProfile
                {
                    UserId = userId,
                    Age = model.Age,
                    Height = model.Height,
                    Weight = model.Weight,
                    Gender = model.Gender,
                    ActivityLevel = model.ActivityLevel,
                    Goal = model.Goal,
                    TargetWeight = model.TargetWeight,

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _userProfileRepository.AddAsync(profile);
                await _userProfileRepository.SaveChangesAsync();
            }
            else
            {
                profile.Age = model.Age;
                profile.Height = model.Height;
                profile.Weight = model.Weight;
                profile.Gender = model.Gender;
                profile.ActivityLevel = model.ActivityLevel;
                profile.Goal = model.Goal;
                profile.TargetWeight = model.TargetWeight;
                profile.UpdatedAt = DateTime.UtcNow;
                await _userProfileRepository.UpdateAsync(profile);
                await _userProfileRepository.SaveChangesAsync();
            }

            // Calculate calorie target
            profile.DailyCalorieTarget = await CalculateDailyCalorieTarget(profile);
            await _userProfileRepository.UpdateAsync(profile);
            await _userProfileRepository.SaveChangesAsync();
        }

        public async Task<UserProfile> GetUserProfileAsync(Guid userId)
        {
            return await _userProfileRepository.GetByUserIdAsync(userId);
        }

        public async Task<int> CalculateDailyCalorieTarget(UserProfile profile)
        {
            // Mifflin-St Jeor Equation
            decimal bmr = profile.Gender switch
            {
                Gender.Male => (10 * profile.Weight) + (6.25m * profile.Height) - (5 * profile.Age) + 5,
                Gender.Female => (10 * profile.Weight) + (6.25m * profile.Height) - (5 * profile.Age) - 161,
                _ => (10 * profile.Weight) + (6.25m * profile.Height) - (5 * profile.Age) // Average
            };

            decimal activityFactor = profile.ActivityLevel switch
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
            decimal goalFactor = profile.Goal switch
            {
                GoalType.WeightLoss => 0.85m, // 15% deficit
                GoalType.WeightGain => 1.15m, // 15% surplus
                GoalType.MuscleBuilding => 1.10m, // 10% surplus
                _ => 1.0m // Maintenance
            };

            return (int)(tdee * goalFactor);
        }
        public string GetBMIStatus(decimal bmi)
        {
            if (bmi < 18.5m) return "Underweight";
            if (bmi < 25m) return "Normal";
            if (bmi < 30m) return "Overweight";
            return "Obese";
        }
    }
}