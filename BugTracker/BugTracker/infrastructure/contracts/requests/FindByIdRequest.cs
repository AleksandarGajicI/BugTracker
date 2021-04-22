using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class FindByIdRequest
    {
        public Guid Id { get; set; }
    }
}
