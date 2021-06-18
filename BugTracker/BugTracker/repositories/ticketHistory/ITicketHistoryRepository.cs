using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;

namespace BugTracker.repositories.ticketHistory
{
    public interface ITicketHistoryRepository : IReadOnlyRepository<TicketHistory>, IPersistanceRepository<TicketHistory>
    {
        public ICollection<TicketHistory> FindHistoryForTicket(Guid id);
    }
}
