using SPCalculator.Core.Entities;
using System.Linq.Expressions;

namespace SPCalculator.Data.Repositories.Abstraction
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); // Birden fazla kayıt döndürür.
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); // Tek bir kayıt döndürür.
        Task<T> GetByIdAsync(Guid id); // Id'ye göre tek bir kayıt döndürür.
        Task<T> UpdateAsync(T entity); // Güncelleme işlemi yapar.
        Task DeleteAsync(T entity); // Silme işlemi yapar.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); // İstediğimiz şartı sağlayan kayıt var mı yok mu onu döndürür.
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null); // Kaç veri var onu döndürür.
    }
}
