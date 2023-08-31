using SPCalculator.Core.Entities;
using SPCalculator.Data.Repositories.Abstraction;

namespace SPCalculator.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable // IAsyncDisposable = IDisposable + Async
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new(); // T Burda Nesne, Generic olarak ne gelirse onu alır. Tek tek repository tanımlamak yerine bu şekilde tanımladık.

        Task<int> SaveAsync(); // Task = Void
        int Save();
    }
}
