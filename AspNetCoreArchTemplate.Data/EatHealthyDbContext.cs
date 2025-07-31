
namespace EatHealthy.Data
{
    using EatHealthy.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class EatHealthyDbContext: IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public EatHealthyDbContext(DbContextOptions<EatHealthyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RecipeProduct> RecipeProducts { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<MealRecipe> MealRecipes { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<DayMeal> DayMeals { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           
        
        }
    }
}
