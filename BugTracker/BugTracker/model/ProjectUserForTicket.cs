using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class ProjectUserForTicket
    {
        public Guid ProjectUserId { get; set; }
        public Guid TicketId { get; set; }

        public DateTime Assigned { get; set; }
        public string Comment { get; set; }
    }
}
