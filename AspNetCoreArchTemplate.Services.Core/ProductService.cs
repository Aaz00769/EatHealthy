using EatHealthy.Data;
using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
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

            /*int productsCount = await this._context
               .Products
               .CountAsync();
            */
            return allProducts;
        }
    }
}
