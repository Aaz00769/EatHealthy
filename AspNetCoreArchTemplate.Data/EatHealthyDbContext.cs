namespace EatHealthy.Data
{
    using EatHealthy.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using System.Reflection.Emit;

    public class EatHealthyDbContext : IdentityDbContext
    {
        public EatHealthyDbContext(DbContextOptions<EatHealthyDbContext> options)
            : base(options)
        {

        }


        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeProduct> RecipeProductProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Apple", Calories = 52 },
                new Product { Id = Guid.NewGuid(), Name = "Banana", Calories = 89 },
                new Product { Id = Guid.NewGuid(), Name = "Carrot", Calories = 41 },
                new Product { Id = Guid.NewGuid(), Name = "Broccoli", Calories = 34 },
                new Product { Id = Guid.NewGuid(), Name = "Chicken Breast", Calories = 165 },
                new Product { Id = Guid.NewGuid(), Name = "Salmon", Calories = 208 },
                new Product { Id = Guid.NewGuid(), Name = "Egg", Calories = 155 },
                new Product { Id = Guid.NewGuid(), Name = "Almonds", Calories = 579 },
                new Product { Id = Guid.NewGuid(), Name = "Brown Rice", Calories = 123 },
                new Product { Id = Guid.NewGuid(), Name = "Oats", Calories = 389 },
                new Product { Id = Guid.NewGuid(), Name = "Milk (Whole)", Calories = 61 },
                new Product { Id = Guid.NewGuid(), Name = "Greek Yogurt", Calories = 59 },
                new Product { Id = Guid.NewGuid(), Name = "Cheddar Cheese", Calories = 403 },
                new Product { Id = Guid.NewGuid(), Name = "Spinach", Calories = 23 },
                new Product { Id = Guid.NewGuid(), Name = "Tomato", Calories = 18 },
                new Product { Id = Guid.NewGuid(), Name = "Potato", Calories = 77 },
                new Product { Id = Guid.NewGuid(), Name = "Sweet Potato", Calories = 86 },
                new Product { Id = Guid.NewGuid(), Name = "Beef (Lean)", Calories = 250 },
                new Product { Id = Guid.NewGuid(), Name = "Tuna (Canned in Water)", Calories = 132 },
                new Product { Id = Guid.NewGuid(), Name = "Shrimp", Calories = 99 },
                new Product { Id = Guid.NewGuid(), Name = "Tofu", Calories = 76 },
                new Product { Id = Guid.NewGuid(), Name = "Lentils", Calories = 116 },
                new Product { Id = Guid.NewGuid(), Name = "Chickpeas", Calories = 164 },
                new Product { Id = Guid.NewGuid(), Name = "Kidney Beans", Calories = 127 },
                new Product { Id = Guid.NewGuid(), Name = "Cucumber", Calories = 16 },
                new Product { Id = Guid.NewGuid(), Name = "Lettuce", Calories = 15 },
                new Product { Id = Guid.NewGuid(), Name = "Zucchini", Calories = 17 },
                new Product { Id = Guid.NewGuid(), Name = "Mushrooms", Calories = 22 },
                new Product { Id = Guid.NewGuid(), Name = "Avocado", Calories = 160 },
                new Product { Id = Guid.NewGuid(), Name = "Pineapple", Calories = 50 },
                new Product { Id = Guid.NewGuid(), Name = "Orange", Calories = 47 },
                new Product { Id = Guid.NewGuid(), Name = "Blueberries", Calories = 57 },
                new Product { Id = Guid.NewGuid(), Name = "Strawberries", Calories = 32 },
                new Product { Id = Guid.NewGuid(), Name = "Watermelon", Calories = 30 },
                new Product { Id = Guid.NewGuid(), Name = "Peanut Butter", Calories = 588 },
                new Product { Id = Guid.NewGuid(), Name = "Cottage Cheese", Calories = 98 },
                new Product { Id = Guid.NewGuid(), Name = "Quinoa", Calories = 120 },
                new Product { Id = Guid.NewGuid(), Name = "Barley", Calories = 354 },
                new Product { Id = Guid.NewGuid(), Name = "Pumpkin", Calories = 26 },
                new Product { Id = Guid.NewGuid(), Name = "Green Peas", Calories = 81 },
                new Product { Id = Guid.NewGuid(), Name = "Cauliflower", Calories = 25 },
                new Product { Id = Guid.NewGuid(), Name = "Eggplant", Calories = 25 },
                new Product { Id = Guid.NewGuid(), Name = "Raspberries", Calories = 52 },
                new Product { Id = Guid.NewGuid(), Name = "Black Beans", Calories = 132 },
                new Product { Id = Guid.NewGuid(), Name = "Coconut Milk", Calories = 230 },
                new Product { Id = Guid.NewGuid(), Name = "Dates", Calories = 277 },
                new Product { Id = Guid.NewGuid(), Name = "Honey", Calories = 304 },
                new Product { Id = Guid.NewGuid(), Name = "Green Tea", Calories = 1 },
                new Product { Id = Guid.NewGuid(), Name = "Dark Chocolate (85%)", Calories = 598 });

       
        }
    }
}
