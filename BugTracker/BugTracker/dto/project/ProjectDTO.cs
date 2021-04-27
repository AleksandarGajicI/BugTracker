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
        public ICollection<ProjectUserDTO> UsersOnProject { get; set; }
        public ICollection<ProjectUserRequestDTO> PendingRequests { get; set; }
        public ICollection<ProjectUserRequestDTO> DeniedRequests { get; set; }
        public ICollection<Ticket> RecentTickets { get; set; }
        public int NumOfTickets { get; set; }

        public ProjectDTO() 
        {
            UsersOnProject = new List<ProjectUserDTO>();
            PendingRequests = new List<ProjectUserRequestDTO>();
            DeniedRequests = new List<ProjectUserRequestDTO>();
            RecentTickets = new List<Ticket>();
        }

    }
}
