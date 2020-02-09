using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WaterPoloStat.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Query(params Expression<Func<T, object>>[] propertiesToInclude);
        Task<T> FindByIdAsync(object id, CancellationToken cancellationToken);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] propertiesToInclude);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<ICollection<T>> FindAllAsync(CancellationToken cancellationToken);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<bool> AnyAsync(CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);

        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null, CancellationToken cancellationToken = default);

        void Insert(T entity);
        Task<int> InsertAndCommitAsync(T entity, CancellationToken cancellationToken);
        void Insert(IEnumerable<T> entities);
        Task<int> InsertAndCommitAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        void Update(T entity);
        Task<int> UpdateAndCommitAsync(T entity, CancellationToken cancellationToken);
        void Update(IEnumerable<T> entities);
        Task<int> UpdateAndCommitAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        void Delete(T entity);
        Task<int> DeleteAndCommitAsync(T entity, CancellationToken cancellationToken);
        void Delete(IEnumerable<T> entities);
        Task<int> DeleteAndCommitAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    }
}
