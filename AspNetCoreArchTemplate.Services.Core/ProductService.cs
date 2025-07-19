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

namespace EatHealthy.Services.Core
{
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
    }
}
