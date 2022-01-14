using Infra.Data.Minimal.Contexts;

namespace Infra.Data.Minimal.Repository.Contracts
{
    public interface IGenericRepository<TContext, TEntity>
        where TEntity : class
        where TContext : AppDbContext
    {
        Task InsertAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
        Task<List<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        Task<int> CountRecordsAsync();
        bool Exists(Guid id);
        void InsertSync(TEntity obj);
        void UpdateSync(TEntity obj);
        void DeleteSync(TEntity obj);
        List<TEntity> FindAllSync();
        TEntity FindByIdSync(Guid id);
        int CountRecordsSync();

    }
}
