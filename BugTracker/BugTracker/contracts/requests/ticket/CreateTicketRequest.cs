using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.ticket
{
    public class CreateTicketRequest
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string TicketType { get; set; }
        public Guid ProjectId { get; set; }

        public Guid StatusId { get; set; }
    }
}
