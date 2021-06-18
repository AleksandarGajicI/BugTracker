using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.repositories.ticketHistory
{
    public class TicketHistoryRepository : GenericRepository<TicketHistory>, ITicketHistoryRepository
    {
        public TicketHistoryRepository(BugTrackerDatabase context, IUnitOfWork uow) : base(context, uow)
        { }

        public ICollection<TicketHistory> FindHistoryForTicket(Guid id)
        {
            return this._table.Where(t => t.Ticket.Id.Equals(id.ToString())).ToList();
        }
    }
}
