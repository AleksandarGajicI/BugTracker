using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.domain.events
{
    public class DomainEvents
    {
        private readonly IDomainEventHandlerFactory _handlerFactory;

        public DomainEvents(IDomainEventHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public void Raise<T>(T domainEvent)
            where T : IDomainEvent<EntityBase>
        {
            _handlerFactory.GetDomainEventHandlersFor(domainEvent)
                .ForEach(x => x.Handle(domainEvent));
        }
    }
}
