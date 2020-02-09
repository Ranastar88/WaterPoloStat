using System;
using System.Linq;
using System.Threading.Tasks;
using WaterPoloStat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace WaterPoloStat.Services
{
    public class UnitOfWork : IUnitOfWork
  {
      private readonly DbContext _dbContext;

      private readonly Dictionary<Type, object> _repositories;

      public UnitOfWork(DbContext dbContext)
      {
          _dbContext = dbContext;
          _repositories = new Dictionary<Type, object>();
      }
 
      public IRepository<T> Repository<T>() where T : class
      {
          if (_repositories.Keys.Contains(typeof(T)))
          {
              return _repositories[typeof(T)] as IRepository<T>;
          }
 
          IRepository<T> repo = new Repository<T>(_dbContext);
          _repositories.Add(typeof(T), repo);
          return repo;
      }
 
      public async Task<int> CommitAsync(CancellationToken cancellationToken)
      {
          try
          {
              var result = await _dbContext.SaveChangesAsync(cancellationToken);
              return result;
          }
          catch (Exception e)
          {
              return -1;
          }
      }
 
      public void Rollback()
      {
          _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
      }
  }
}
