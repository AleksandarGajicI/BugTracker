using System;

namespace BugTracker.contracts.requests.projectUserReq
{
    public class ProjectUserReplyRequest
    {
        public Guid RequestId { get; set; }
        public Guid UserAssignedId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
