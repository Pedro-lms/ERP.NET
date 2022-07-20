using System;

namespace Pedro.Web.Events.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
