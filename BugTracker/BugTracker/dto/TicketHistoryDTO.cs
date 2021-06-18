using System;

namespace BugTracker.dto
{
    public class TicketHistoryDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string ChangedProperty { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Changed { get; set; }
        public string UserName { get; set; }
    }
}
