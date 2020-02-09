using WaterPoloStat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WaterPoloStat.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<T> _repository;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Repository<T>();
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] propertiesToInclude)
        {
            return _repository.Query(propertiesToInclude);
        }

        public async Task<T> FindByIdAsync(object id, CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(id, cancellationToken);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _repository.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] propertiesToInclude)
        {
            return await _repository.SingleOrDefaultAsync(predicate, cancellationToken, propertiesToInclude);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _repository.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _repository.LastOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<ICollection<T>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.FindAllAsync(cancellationToken);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _repository.FindAllAsync(predicate, cancellationToken);
        }

        public async Task<bool> AnyAsync(CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _repository.AnyAsync(predicate, cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _repository.CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null, CancellationToken cancellationToken = default)
        {
            return await _repository.FilterAsync(filter, orderBy, includeProperties, page, pageSize, cancellationToken);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public async Task<int> InsertAndCommitAsync(T entity, CancellationToken cancellationToken)
        {
            _repository.Insert(entity);
            return await _uow.CommitAsync(cancellationToken);
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public async Task<int> InsertAndCommitAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _repository.Insert(entities);
            return await _uow.CommitAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public async Task<int> UpdateAndCommitAsync(T entity, CancellationToken cancellationToken)
        {
            _repository.Update(entity);
            return await _uow.CommitAsync(cancellationToken);
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public async Task<int> UpdateAndCommitAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _repository.Update(entities);
            return await _uow.CommitAsync(cancellationToken);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public async Task<int> DeleteAndCommitAsync(T entity, CancellationToken cancellationToken)
        {
            _repository.Delete(entity);
            return await _uow.CommitAsync(cancellationToken);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public async Task<int> DeleteAndCommitAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _repository.Delete(entities);
            return await _uow.CommitAsync(cancellationToken);
        }
    }

}
