using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.project
{
    public class CreateProjectRequest : BaseRequest
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }

        public Guid OwnerId { get; set; }
        public string UserName { get; set; }
    }
}
