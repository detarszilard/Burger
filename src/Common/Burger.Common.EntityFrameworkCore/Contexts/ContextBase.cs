using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Burger.Common.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Burger.Common.EntityFrameworkCore.Contexts
{
    public abstract class ContextBase<TContext> : DbContext
        where TContext : DbContext
    {
        public ContextBase(DbContextOptions<TContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplySoftDeleteConfiguration();
            modelBuilder.ApplyGlobalIdCofiguration();
            modelBuilder.ApplyConfigurationsFromAssembly(GetAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changeCount = await base.SaveChangesAsync(cancellationToken);

            await DispatchNotifications(cancellationToken);

            return changeCount;
        }

        private async Task DispatchNotifications(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<IEntity>().Where(e => e.Entity.DomainNotifications.Any());
            var notifications = entries.SelectMany(entry => entry.Entity.DomainNotifications).ToList();

            foreach (var entry in entries)
            {
                entry.Entity.ClearDomainNotifications();
            }

            var publisher = this.GetService<IPublisher>();

            foreach (var notification in notifications)
            {
                await publisher.Publish(notification);
            }
        }

        protected virtual Assembly GetAssembly()
            => GetType().Assembly;
    }
}
