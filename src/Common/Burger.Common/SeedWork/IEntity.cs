using MediatR;
using System.Collections.Generic;

namespace Burger.Common.SeedWork
{
    public interface IEntity
    {
        string Id { get; }

        IReadOnlyCollection<INotification> DomainNotifications { get; }

        void ClearDomainNotifications();
    }
}
