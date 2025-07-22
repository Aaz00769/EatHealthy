using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository
{
    internal class BaseRepository<T, TId> : IRepository<T, TId> where T : class
    {
        private readonly EatHealthyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(EatHealthyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> All()
        {
            return _dbSet;
        }

        public IQueryable<T> AllAsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._dbSet.SingleOrDefaultAsync(predicate);
        }

  
        public async Task SoftDeleteAsync(T entity)
        {
            var property = typeof(T).GetProperty("IsDeleted");
            if (property == null)
                throw new InvalidOperationException($"{typeof(T).Name} does not support soft delete.");

            property.SetValue(entity, true);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> AllAttached()
        {
            return _dbSet;
        }
    }
}
