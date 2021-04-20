using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class ProjectUserReq : EntityBase
    {
        public Guid Id { get; set; }
        public DateTime RequestSent { get; set; }
        public bool Accepted { get;     set; }
        public string Message { get; set; }





        public Guid ProjectId { get; set; }
        public Project Project { get; set; }


        public Guid UserAssignedId { get; set; }
        public User UserAssigned { get; set; }

        public Role Role { get; set; }

        public User Sender { get; set; }

        public ICollection<ProjectUserForTicket> AssignedForTicket { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
