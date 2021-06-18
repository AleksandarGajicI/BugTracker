using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.ticket
{
    public class UpdateTicketRequest : RequestBase
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public Guid StatusId { get; set; }
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }
    }
}
