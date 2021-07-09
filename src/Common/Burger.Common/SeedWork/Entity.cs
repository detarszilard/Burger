using System;
using System.Collections.Generic;
using MediatR;

namespace Burger.Common.SeedWork
{
    public class Entity : IEntity, ISoftDelete
    {
        int? _requestedHashCode;
        private string _id;
        private bool _isDeleted;
        private List<INotification> _notifications = new List<INotification>();

        public string Id
        {
            get => _id;
            protected set => _id = value;
        }

        public bool IsDeleted => _isDeleted;

        public IReadOnlyCollection<INotification> DomainNotifications => _notifications;

        public virtual void Delete()
        {
            _isDeleted = true;
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _notifications.Add(eventItem);
        }

        public void ClearDomainNotifications()
        {
            _notifications.Clear();
        }

        public bool IsTransient()
        {
            return string.IsNullOrEmpty(this.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            var item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

    }
}
