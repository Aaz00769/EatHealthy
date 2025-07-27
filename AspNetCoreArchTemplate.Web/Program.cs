namespace EatHealthy.Web
{
    using AspNetCoreArchTemplate.Data.Repository;
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using Data;
    using EatHealthy.Data.Models;
    using EatHealthy.Services.Core;
    using EatHealthy.Services.Core.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
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
            


            builder.Services.AddScoped<IDayService, DayService>();
             builder.Services.AddScoped<IMealService, MealService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddTransient<IProductService, ProductService>();
           

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IDayRepository, DayRepository>();
            builder.Services.AddScoped<IMealRepository, MealRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IRecipeFacade, RecipeFacade>();

            WebApplication? app = builder.Build();
            
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

            app.Run();
        }
    }
}
