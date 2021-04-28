using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class DeleteRequest : RequestBase
    {
        public Guid Id { get; set; }
    }
}
