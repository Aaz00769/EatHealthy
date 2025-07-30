using EatHealthy.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        // Basic Metrics
        public int Age { get; set; }
        public decimal Height { get; set; } // in cm
        public decimal Weight { get; set; } // in kg
        public Gender Gender { get; set; }

        // Activity Level
        public ActivityLevel ActivityLevel { get; set; }

        // Goals
        public GoalType Goal { get; set; }
        public decimal TargetWeight { get; set; }
        public int DailyCalorieTarget { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
