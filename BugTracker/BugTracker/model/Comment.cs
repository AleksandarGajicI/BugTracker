using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }

        public ProjectUserReq Commenter { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
