

namespace AspNetCoreArchTemplate.Data.Repository
{
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data;
    using EatHealthy.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(EatHealthyDbContext context) 
            : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetAllDeletedAsync()
        {
            return await _context.Products
                .Where(p => p.IsDeleted)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
