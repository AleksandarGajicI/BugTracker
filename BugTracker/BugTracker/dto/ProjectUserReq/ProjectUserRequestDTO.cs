using BugTracker.dto.project;
using System;

namespace BugTracker.dto.ProjectUserReq
{
    public class ProjectUserRequestDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public RoleDTO Role { get; set; }
        public ProjectAbbreviatedDTO Project { get; set; }
        public UserAbbreviatedDTO User { get; set; }
        public DateTime InvitedAt { get; set; }
        public string Message { get; set; }
    }
}
