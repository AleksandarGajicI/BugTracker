using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class CreateRequest<T>
        where T : EntityBase
    {
        public T Entity { get; set; }
    }
}
