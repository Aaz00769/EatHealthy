namespace AspNetCoreArchTemplate.Data
{
    using AspNetCoreArchTemplate.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

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
        }
    }
}
