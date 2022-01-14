using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Minimal.Contexts;
using Infra.Data.Minimal.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Minimal.Repository.Generics
{
    public abstract class GenericRepository<TContext, TEntity> : IGenericRepository<TContext, TEntity>, IDisposable
         where TContext : AppDbContext, new()
         where TEntity : class
    {
        protected AppDbContext _db;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            _db = new TContext();
            _dbSet = _db.Set<TEntity>();
        }
        public virtual async Task InsertAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
            await _db.SaveChangesAsync();
        }
        public virtual void InsertSync(TEntity obj)
        {
            _dbSet.Add(obj);
            _db.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            _dbSet.Update(obj);
            await _db.SaveChangesAsync();
        }

        public virtual void UpdateSync(TEntity obj)
        {
            _dbSet.Update(obj);
            _db.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity obj)
        {
            _dbSet.Remove(obj);
            await _db.SaveChangesAsync();
        }
        public virtual void DeleteSync(TEntity obj)
        {
            _dbSet.Remove(obj);
            _db.SaveChanges();
        }
        public virtual async Task<List<TEntity>> FindAllAsync()
        {
            return await _dbSet.AsNoTracking().Take(0).ToListAsync();
        }
        public virtual List<TEntity> FindAllSync()
        {
            return _dbSet.AsNoTracking().Take(100).ToList();
        }

        public virtual async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual TEntity FindByIdSync(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<int> CountRecordsAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual int CountRecordsSync()
        {
            return _dbSet.Count();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool Exists(Guid id)
        {
            return _dbSet.FindAsync(id) == null ? false : true;
        }
    }

}
