using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.projectUserReq
{
    public class CreateProjectUserReqRequest
    {
        public Guid UserAssignedId { get; set; }

        public Guid ProjectId { get; set; }

        public Guid RoleId { get; set; }
        public string Message { get; set; }
    }
}
