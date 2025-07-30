using EatHealthy.Data.Common;
using EatHealthy.GCommon.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels.Profile
{
    public class UserProfileModel
    {
        [Required]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required]
        [Range(100, 250, ErrorMessage = "Height must be between 100 and 250 cm")]
        public decimal Height { get; set; }

        [Required]
        [Range(30, 300, ErrorMessage = "Weight must be between 30 and 300 kg")]
        public decimal Weight { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public ActivityLevel ActivityLevel { get; set; }

        [Required]
        public GoalType Goal { get; set; }

        [Range(30, 300, ErrorMessage = "Target weight must be between 30 and 300 kg")]
        public decimal TargetWeight { get; set; }
    }
}