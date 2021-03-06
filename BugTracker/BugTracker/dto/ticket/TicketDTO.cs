using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto.ticket
{
    public class TicketDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public TicketStatusDTO Status { get; set; }

        public UserAbbreviatedDTO Reporter { get; set; }

        public ICollection<CommentDTO> RecentComments { get; set; }
        public ICollection<string> AssignedUsers { get; set; }
    }
}
