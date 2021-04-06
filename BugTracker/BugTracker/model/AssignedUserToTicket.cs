using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class AssignedUserToTicket
    {
        public Guid UserAssignedRequiestId { get; set; }
        public Guid TicketId { get; set; }

        public DateTime Assigned { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
    }
}
