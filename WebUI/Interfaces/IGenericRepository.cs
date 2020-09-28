using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebUI.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children);
        T FirstEntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children);
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> filter = null, int? page = null, int? pageSize = null);
        Task<List<TOut>> FindAsync<TOut>(out int total, Expression<Func<T, bool>> filter = null, Expression<Func<T, TOut>> select = null, int? page = null, int? pageSize = null, bool noTracking = false);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(object EntityId);
        void Delete(T Entity);
    }

    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void SaveWithTransaction();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
