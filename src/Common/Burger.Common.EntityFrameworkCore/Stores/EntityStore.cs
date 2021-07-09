using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Burger.Common.EntityFrameworkCore.ResourceFilters;
using Burger.Common.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Burger.Common.EntityFrameworkCore.Stores
{
    public class EntityStore<TContext, TEntity> : IEntityStore<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
    {
        private readonly TContext _context;
        private readonly IResourceFilter<TEntity> _resourceFilter;

        public EntityStore(TContext context, IResourceFilter<TEntity> resourceFilter)
        {
            _context = context;
            _resourceFilter = resourceFilter;
        }

        public virtual void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public virtual Task<TEntity> GetEntityAsync(string id, CancellationToken cancellationToken = default, bool skipAuthorization = false)
        {
            return GetQuery(skipAuthorization).SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity is ISoftDelete softDelete)
            {
                softDelete.Delete();
            }
            else
            {
                _context.Remove(entity);
            }
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        protected IQueryable<TEntity> GetQuery(bool skipAuthorization = false)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            return skipAuthorization
                ? query
                : _resourceFilter.AuthorizeQuery(query);
        }
    }
}
