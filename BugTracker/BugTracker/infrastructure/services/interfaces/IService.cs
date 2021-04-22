using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.services
{
    public interface IService<T> : IReadOnlyService<T>, IPersistanceService<T>
        where T : EntityBase
    {
    }
}
