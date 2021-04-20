using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.domain.events
{
    public interface IDomainEvent<T> where T : EntityBase
    {
        public T entity { get; set; }
    }
}
