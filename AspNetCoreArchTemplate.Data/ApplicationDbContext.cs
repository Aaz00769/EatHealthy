namespace AspNetCoreArchTemplate.Data
{
    using AspNetCoreArchTemplate.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Product>()
                .HasData(
                new Product() { Id = 1, Calories = 100, Name = "Banana" },
                new Product() { Id = 2, Calories = 200, Name = "Apple" });
                
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Product> Products { get; set; }
    }
}
