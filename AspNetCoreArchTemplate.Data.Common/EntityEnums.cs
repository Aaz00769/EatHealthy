using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Common
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum ActivityLevel
    {
        Sedentary,      // Little or no exercise
        LightlyActive,  // Light exercise 1-3 days/week
        ModeratelyActive, // Moderate exercise 3-5 days/week
        VeryActive,     // Hard exercise 6-7 days/week
        ExtremelyActive // Very hard exercise & physical job
    }

    public enum GoalType
    {
        WeightLoss,
        WeightMaintenance,
        WeightGain,
        MuscleBuilding
    }
}
