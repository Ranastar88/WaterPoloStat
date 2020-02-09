using System.Threading;
using System.Threading.Tasks;

namespace WaterPoloStat.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> CommitAsync(CancellationToken cancellationToken);
        void Rollback();

    }
}
