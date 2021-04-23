using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.project
{
    public class UpdateProjectRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }

    }
}
