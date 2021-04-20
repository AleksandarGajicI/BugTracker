using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.domain.events
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent<EntityBase>
    {
        public void Handle(TEvent domainEvent);
    }
    
}
