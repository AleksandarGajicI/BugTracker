using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Ticket
    {

        public enum TicketType { 
                BUG_ERROR, FEATURE_REQUEST, OTHER, DOCUMENT_REQUEST 
        }



        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public TicketType Type { get; set; }


        public ProjectUserReq Reporter { get; set; }
        public Project Project { get; set; }

        public TicketStatus Status { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<ProjectUserForTicket> AssignedUsers { get; set; }


    }
}
