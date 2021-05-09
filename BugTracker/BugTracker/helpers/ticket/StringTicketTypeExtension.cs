using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BugTracker.model.Ticket;

namespace BugTracker.helpers.ticket
{
    public static class StringTicketTypeExtension
    {
        public static TicketType ConvertToTicketType(this string ticketType)
        {
            
            switch (ticketType.ToLower())
            {
                case "bugerror":
                    return TicketType.BUG_ERROR;
                case "featurerequest":
                    return TicketType.FEATURE_REQUEST;
                case "documentrequest":
                    return TicketType.DOCUMENT_REQUEST;
                case "other":
                    return TicketType.OTHER;
                default:
                    return TicketType.UNDEFINED;
            }
        }
    }
}
