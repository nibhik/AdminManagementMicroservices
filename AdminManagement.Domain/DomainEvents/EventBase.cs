using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AdminManagement.Domain.DomainEvents
{
    public abstract class EventBase : INotification
    {
        public DateTimeOffset createdOn { get; set; } = DateTime.UtcNow;

    }
}
