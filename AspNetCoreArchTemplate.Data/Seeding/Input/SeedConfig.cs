using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Seeding.Input
{
    public class SeedConfig
    {
        public int UserCount { get; set; } = 5;
        public int ProductCount { get; set; } = 20;
        public int RecipesPerUser { get; set; } = 3;
        public int MealsPerUser { get; set; } = 3;
        public int DaysPerUser { get; set; } = 7;
    }
}
