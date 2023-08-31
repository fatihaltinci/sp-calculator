using Microsoft.EntityFrameworkCore;
using SPCalculator.Core.Entities;
using SPCalculator.Data.Context;
using SPCalculator.Data.Repositories.Abstraction;
using System.Linq.Expressions;

namespace SPCalculator.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() // T Burda Nesne, Generic olarak ne gelirse onu alır.
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); } // T tipindeki tabloyu alır.

        public async Task AddAsync(T entity) // Task = Void gibi bir şey. Async = Asenkron çalışır.
        {
            await Table.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool >> predicate = null, params Expression<Func<T, object>>[] includeProperties) // includeProperties birbirine bağlanan entityleri döndürüyor. 
        {
            IQueryable<T> query = Table;
            if (predicate != null) // predicate ikinci opsiyonu kullanmak için default olarak null veriliyor
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty); // includeProperties birbirine bağlanan entityleri döndürüyor. 
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty); // includeProperties birbirine bağlanan entityleri döndürüyor. 
                }
            }
            return await query.SingleAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await Table.CountAsync();
            }
            else
            {
                return await Table.CountAsync(predicate);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
    }
}
