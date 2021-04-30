using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto
{
    public class TicketStatusDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
