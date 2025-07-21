

namespace EatHealthy.Services.Core
{
    using EatHealthy.Data;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using EatHealthy.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProductService : IProductService
    {
        private readonly EatHealthyDbContext _context;

        public ProductService(EatHealthyDbContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<ProductViewModel>> GetAllProductAsync()
        {
            IEnumerable<ProductViewModel> allProducts = await this._context
                .Products
                .Where(p => !p.IsDeleted)
                .AsNoTracking()
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,  
                    Calories = p.Calories.ToString(),

                })
                .ToListAsync();

           
            return allProducts;
        }

        public async Task AddProductAsync(ProductFormInputModel inputModel)
        {
            Product newProduct = new Product()
            {
                Name = inputModel.ProductName,
                Calories = inputModel.Calories,
                Proteins=inputModel.Proteins,
                Fats=inputModel.Fats,
                Carbohydrates=inputModel.Carbohydrates
            };

            await this._context.Products.AddAsync(newProduct);
            await this._context.SaveChangesAsync();


        }

        public async Task<bool> ProductExist(string name)
        {
            return await this._context.Products.AnyAsync(p => p.Name == name);
        }

        public async Task EditProductAsync(Guid id, ProductFormInputModel inputModel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            product.Name = inputModel.ProductName;
            product.Calories = inputModel.Calories;
            product.Proteins = inputModel.Proteins;
            product.Fats = inputModel.Fats;
            product.Carbohydrates = inputModel.Carbohydrates;

            await _context.SaveChangesAsync();
        }

        public async Task<ProductFormInputModel?> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;

            return new ProductFormInputModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Calories = product.Calories,
                Fats = product.Fats,
                Proteins = product.Proteins,
                Carbohydrates = product.Carbohydrates
            };
        }

        public async Task<bool> SoftDeletProductAsync(Guid id)
        {

            Product? productToDelete = await this._context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToDelete == null) return false;

            productToDelete.IsDeleted=true;

            await this._context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> HardDeleteProductAsync(Guid id)
        {
            Product? productToDelete = await this._context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productToDelete == null) return false;
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<ProductViewModel>> GetAllDeletedProductAsync()
        {
            IEnumerable<ProductViewModel> allProducts = await this._context
              .Products
              .Where(p => p.IsDeleted)
              .AsNoTracking()
              .Select(p => new ProductViewModel()
              {
                  Id = p.Id,
                  Name = p.Name,
                  Calories = p.Calories.ToString(),

              })
              .ToListAsync();


            return allProducts;
        }

        public async Task<bool> RestoreProductAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null || !product.IsDeleted) return false;

            product.IsDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
