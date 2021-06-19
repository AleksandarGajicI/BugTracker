using System;

namespace BugTracker.dto.ticket
{
    public class TicketForProjectDTO : BaseDTO
    {
        public String Title { get; set; }
        public DateTime Deadline { get; set; }
        public String Type { get; set; }
        public String Status { get; set; }
        public Guid Id { get; set; }
    }

    //  id: string;
    //title: string;
    //deadline: string;
    //type: string;
    //status: string;
}
