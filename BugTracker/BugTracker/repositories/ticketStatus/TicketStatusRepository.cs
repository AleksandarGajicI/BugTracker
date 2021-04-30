using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.model;

namespace BugTracker.repositories.ticketStatus
{
    public class TicketStatusRepository : GenericReadOnlyRepository<TicketStatus>, ITicketStatusRepository
    {
        public TicketStatusRepository(BugTrackerDatabase context)
            : base(context)
        { 
        }
    }
}
