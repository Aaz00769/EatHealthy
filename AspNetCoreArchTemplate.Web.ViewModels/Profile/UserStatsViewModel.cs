using EatHealthy.Data.Common;
using EatHealthy.Data.Models;
using System;

namespace EatHealthy.Web.ViewModels.Profile
{
    public class UserStatsViewModel
    {
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal TargetWeight { get; set; }
        public Gender Gender { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public GoalType Goal { get; set; }
        public int DailyCalorieTarget { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Progress properties
        public decimal WeightToTarget => TargetWeight - Weight;
        public string ProgressDirection => WeightToTarget > 0 ? "gain" : "lose";
        public decimal ProgressPercentage
        {
            get
            {
                if (TargetWeight == Weight) return 100;

                var initialWeight = Weight; // For simplicity, using current as initial
                var totalChange = Math.Abs(TargetWeight - initialWeight);
                var currentChange = Math.Abs(Weight - initialWeight);

                return totalChange > 0 ? Math.Min(100, (currentChange / totalChange) * 100) : 0;
            }
        }

        // BMI calculations
        public decimal BMI => Weight / ((Height / 100) * (Height / 100));
        public string BMIStatus
        {
            get
            {
                if (BMI < 18.5m) return "Underweight";
                if (BMI < 25m) return "Normal";
                if (BMI < 30m) return "Overweight";
                return "Obese";
            }
        }
    }
}