using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto.comment
{
    public class CommentCreateDTO
    {
        public string Message { get; set; }
        public Guid TicketId { get; set; }
    }
}
