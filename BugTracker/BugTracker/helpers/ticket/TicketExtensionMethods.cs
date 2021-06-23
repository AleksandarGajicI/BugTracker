using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.ticket
{
    public static class TicketExtensionMethods
    {
        public static IQueryable<Ticket> ApplyFilterOptions(this IQueryable<Ticket> query) 
        {
            return query;
        }

    }
}
