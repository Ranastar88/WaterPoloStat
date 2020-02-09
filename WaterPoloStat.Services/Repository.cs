using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WaterPoloStat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace WaterPoloStat.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] propertiesToInclude)
        {
            var query = _context.Set<T>().AsQueryable();
            return propertiesToInclude == null ? query : propertiesToInclude.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T> FindByIdAsync(object id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(new[] { id }, cancellationToken);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] propertiesToInclude)
        {
            if (propertiesToInclude == null) return await SingleOrDefaultAsync(predicate, cancellationToken);

            var query = _context.Set<T>().AsQueryable();
            return await propertiesToInclude.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().LastOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<ICollection<T>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AnyAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            var exist = _context.Set<T>().Where(predicate);
            return await exist.AnyAsync(cancellationToken);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            //_context.Entry(entity).State = EntityState.Detached;
            //_context.Set<T>().Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includeProperties != null)
            {
                foreach (
                    var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync(cancellationToken);
        }

    }
}
