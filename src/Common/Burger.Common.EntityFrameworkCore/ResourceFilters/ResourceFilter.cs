using Burger.Common.SeedWork;
using System.Linq;

namespace Burger.Common.EntityFrameworkCore.ResourceFilters
{
    public class ResourceFilter<TEntity> : IResourceFilter<TEntity>
        where TEntity : IEntity
    {
        public virtual IQueryable<TEntity> AuthorizeQuery(IQueryable<TEntity> query)
        {
            return query;
        }
    }
}
