using System.Linq;
using Burger.Common.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Burger.Common.EntityFrameworkCore.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var entries = eventData.Context.ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is ISoftDelete);

            foreach (var entry in entries)
            {
                entry.State = EntityState.Modified;
                ((ISoftDelete)entry).Delete();
            }

            return result;
        }
    }
}
