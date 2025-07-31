// Seeding/DatabaseSeeder.cs
using AspNetCoreArchTemplate.Data.Seeding.Dtos;
using AspNetCoreArchTemplate.Data.Seeding.Input;
using EatHealthy.Data;
using EatHealthy.Data.Models;

using EatHealthy.Seeding.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatHealthy.Seeding
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider, SeedConfig config)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<EatHealthyDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            // Apply pending migrations
            await context.Database.MigrateAsync();

            // Seed roles and admin user
            await SeedCoreDataAsync(roleManager, userManager);

            // Seed regular users
            var regularUsers = await SeedUsersAsync(userManager, config.UserCount);

            // Seed products
            var products = await SeedProductsAsync(context, config.ProductCount);

            // Seed recipes
            var recipes = await SeedRecipesAsync(context, regularUsers, products, config.RecipesPerUser);

            // Seed meals
            var meals = await SeedMealsAsync(context, regularUsers, recipes, config.MealsPerUser);

            // Seed days
            await SeedDaysAsync(context, regularUsers, meals, config.DaysPerUser);

            // Seed profiles
            await SeedProfilesAsync(context, regularUsers);
        }

        private static async Task SeedCoreDataAsync(
            RoleManager<IdentityRole<Guid>> roleManager,
            UserManager<AppUser> userManager)
        {
            // Seed roles
            foreach (var role in RoleData.GetRoles())
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }

            // Seed admin user
            var adminInput = AdminData.GetAdminInput();
            var adminUser = await userManager.FindByEmailAsync(adminInput.Email);

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminInput.Email,
                    Email = adminInput.Email,
                    EmailConfirmed = true,
                    ProfileCompleted = true
                };

                var result = await userManager.CreateAsync(adminUser, adminInput.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Administrator");
                }
            }
        }

        private static async Task<List<AppUser>> SeedUsersAsync(
            UserManager<AppUser> userManager, int count)
        {
            var users = new List<AppUser>();
            var userGenerator = new UserGenerator();

            for (int i = 0; i < count; i++)
            {
                var userInput = userGenerator.GenerateUserInput(i + 1);
                var user = await userManager.FindByEmailAsync(userInput.Email);

                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = userInput.Email,
                        Email = userInput.Email,
                        EmailConfirmed = true,
                        ProfileCompleted = true
                    };

                    var result = await userManager.CreateAsync(user, userInput.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "User");
                        users.Add(user);
                    }
                }
                else
                {
                    users.Add(user);
                }
            }

            return users;
        }

        private static async Task<List<Product>> SeedProductsAsync(
            EatHealthyDbContext context, int count)
        {
            if (await context.Products.AnyAsync())
                return await context.Products.ToListAsync();

            var products = ProductGenerator.GenerateProducts(count);
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            return products;
        }

        private static async Task<List<Recipe>> SeedRecipesAsync(
            EatHealthyDbContext context,
            List<AppUser> users,
            List<Product> products,
            int recipesPerUser
           )
        {
            if (await context.Recipes.AnyAsync())
                return await context.Recipes.ToListAsync();

            var recipes = new List<Recipe>();
            var recipeGenerator = new RecipeGenerator(products);

            foreach (var user in users)
            {
                var userRecipes = recipeGenerator.GenerateRecipes(
                    user.Id,
                    recipesPerUser,
                    isPublic: false
                );


                recipes.AddRange(userRecipes);
               
            }

            // Add public recipes
            var publicRecipes = recipeGenerator.GenerateRecipes(
                users.First().Id,
                5, // Public recipe count
                isPublic: true
            );

            recipes.AddRange(publicRecipes);

            await context.Recipes.AddRangeAsync(recipes);
            await context.SaveChangesAsync();

            return recipes;
        }

        private static async Task<List<Meal>> SeedMealsAsync(
            EatHealthyDbContext context,
            List<AppUser> users,
            List<Recipe> recipes,
            int mealsPerUser)
        {
            if (await context.Meals.AnyAsync())
                return await context.Meals.ToListAsync();

            var meals = new List<Meal>();
            var mealGenerator = new MealGenerator(recipes);

            foreach (var user in users)
            {
                var userRecipes = recipes
                    .Where(r => r.CreatedByUserId == user.Id || r.IsPublic)
                    .ToList();

                var userMeals = mealGenerator.GenerateMeals(
                    user.Id,
                    mealsPerUser,
                    userRecipes
                );

                meals.AddRange(userMeals);
            }

            await context.Meals.AddRangeAsync(meals);
            await context.SaveChangesAsync();

            return meals;
        }

        private static async Task SeedDaysAsync(
            EatHealthyDbContext context,
            List<AppUser> users,
            List<Meal> meals,
            int daysPerUser)
        {
            if (await context.Days.AnyAsync()) return;

            var days = new List<Day>();
            var dayGenerator = new DayGenerator(meals);
            var startDate = DateTime.Today.AddDays(-daysPerUser);

            foreach (var user in users)
            {
                var userMeals = meals
                    .Where(m => m.CreatedByUserId == user.Id)
                    .ToList();

                var userDays = dayGenerator.GenerateDays(
                    user.Id,
                    startDate,
                    daysPerUser,
                    userMeals
                );

                days.AddRange(userDays);
            }

            await context.Days.AddRangeAsync(days);
            await context.SaveChangesAsync();
        }

        private static async Task SeedProfilesAsync(
            EatHealthyDbContext context,
            List<AppUser> users)
        {
            if (await context.UserProfiles.AnyAsync()) return;

            var profiles = new List<UserProfile>();
            var profileGenerator = new ProfileGenerator();

            foreach (var user in users)
            {
                var profile = profileGenerator.GenerateProfile(user.Id);
                profiles.Add(profile);
            }

            await context.UserProfiles.AddRangeAsync(profiles);
            await context.SaveChangesAsync();
        }
    }
}