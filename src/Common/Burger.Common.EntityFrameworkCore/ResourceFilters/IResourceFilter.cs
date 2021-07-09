using Burger.Common.SeedWork;
using System.Linq;

namespace Burger.Common.EntityFrameworkCore.ResourceFilters
{
    public interface IResourceFilter<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> AuthorizeQuery(IQueryable<TEntity> query);
    }
}
