namespace EatHealthy.Web
{
    using AspNetCoreArchTemplate.Data.Repository;
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using AspNetCoreArchTemplate.Data.Seeding.Input;
    using Data;
    using EatHealthy.Data.Models;
    using EatHealthy.Seeding;
    using EatHealthy.Services.Core;
    using EatHealthy.Services.Core.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services
                .AddDbContext<EatHealthyDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services
                .AddIdentity<AppUser, IdentityRole<Guid>>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric= false;
                })
                .AddEntityFrameworkStores<EatHealthyDbContext>()
                .AddDefaultUI()
                 .AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IDayService, DayService>();
            builder.Services.AddScoped<IMealService, MealService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddScoped<IRecommendService, RecommendService>();

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            builder.Services.AddScoped<IDayRepository, DayRepository>();
            builder.Services.AddScoped<IMealRepository, MealRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IRecipeFacade, RecipeFacade>();

            WebApplication? app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    logger.LogInformation("Applying database migrations...");
                    var context = services.GetRequiredService<EatHealthyDbContext>();
                    context.Database.Migrate();
                    logger.LogInformation("Migrations applied successfully");
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Fatal error applying migrations");
                    return; // Stop app if migrations fail
                }
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    logger.LogInformation("Starting database seeding...");

                    var config = new SeedConfig
                    {
                        UserCount = 5,
                        ProductCount = 20,
                        RecipesPerUser = 3,
                        MealsPerUser = 3,
                        DaysPerUser = 7
                    };

                    await DatabaseSeeder.SeedAsync(services, config);
                    logger.LogInformation("Database seeding completed successfully");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Seeding failed");
                }
            }

            app.Run();
        }
    }
}
