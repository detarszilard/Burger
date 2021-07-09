using System.Threading;
using System.Threading.Tasks;
using Burger.Common.SeedWork;

namespace Burger.Common.EntityFrameworkCore.Stores
{
    public interface IEntityStore<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetEntityAsync(string id, CancellationToken cancellationToken = default, bool skipAuthorization = false);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Remove(TEntity entity);

        void Add(TEntity entity);
    }
}
