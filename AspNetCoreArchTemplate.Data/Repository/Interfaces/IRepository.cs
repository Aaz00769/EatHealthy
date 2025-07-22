using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        Task<T?> GetByIdAsync(TId id);

        Task<T?> SingleOrDefaultAsync(Func<T, bool> predicate);

        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> All(); // No filter

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task SoftDeleteAsync(T entity);

        Task DeleteAsync(T entity);

        Task<int> SaveChangesAsync();

        IQueryable<T> AllAttached();
    }
}
