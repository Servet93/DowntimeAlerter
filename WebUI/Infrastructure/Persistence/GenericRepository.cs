using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using WebUI.Interfaces;

namespace WebUI.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveWithTransaction()
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                _context.SaveChanges();
                tScope.Complete();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual T FindById(object EntityId)
        {
            return _dbSet.Find(EntityId);
        }

        public IEnumerable<T> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children)
        {
            IQueryable<T> query = _dbSet;
            foreach (string entity in children)
                query = query.Include(entity);

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public T FirstEntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children)
        {
            IQueryable<T> query = _dbSet;
            foreach (string entity in children)
                query = query.Include(entity);

            return query.FirstOrDefault(filter);
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null, int? page = null, int? pageSize = null)
        {
            IQueryable<T> result = _dbSet;

            if (Filter != null)
                result = _dbSet.Where(Filter);

            if (page.HasValue && pageSize.HasValue)
                result = result.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return result;
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Update(entityToUpdate);
        }

        public virtual void Delete(object entityId)
        {
            T entityToDelete = _dbSet.Find(entityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<List<TOut>> FindAsync<TOut>(out int total, Expression<Func<T, bool>> filter, Expression<Func<T, TOut>> select, int? page = null, int? pageSize = null, bool noTracking = false)
        {
            var data = noTracking ? _dbSet.AsNoTracking() : _dbSet.AsQueryable();

            if (filter != null)
                data = data.Where(@filter);

            total = data.Count();

            if (page.HasValue && pageSize.HasValue)
            {
                page = page.Value == 0 ? 1 : page.Value;
                data = data.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return data.Select(select).ToListAsync();
        }
    }
}
