using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Data.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public ICollection<Recipe> Products { get; set; } = new List<Recipe>();
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<Day> Days { get; set; } = new List<Day>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    }
}

