using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class TicketHistory
    {
        public Guid Id { get; set; }
        public string ChangedProperty { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Changed { get; set; }
        public string UserName { get; set; }

        public Ticket Ticket { get; set; }
    }
}
