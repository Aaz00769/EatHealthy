using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Common
{
    public static class EntityConsts
    {
        public static class Product
        {
            public const int NameMaxLength = 64;
            public const int CaloriesMin = 0;
            public const int CaloriesMax = 2000; 

            public const int MacronutrientMin = 0;
            public const int MacronutrientMax = 500;
        }

    }
}
