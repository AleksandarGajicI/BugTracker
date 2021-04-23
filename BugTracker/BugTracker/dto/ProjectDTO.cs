using BugTracker.dto.ProjectUserReq;
using BugTracker.model;
using System;
using System.Collections.Generic;

namespace BugTracker.dto
{
    public class ProjectDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        ICollection<ProjectUserDTO> UsersOnProject { get; set; }
        ICollection<ProjectUserRequestDTO> PendingRequests { get; set; }
        ICollection<ProjectUserRequestDTO> DeniedRequests { get; set; }
        ICollection<Ticket> RecentTickets { get; set; }
        public int NumOfTickets { get; set; }

    }
}
