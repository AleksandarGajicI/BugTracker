using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.ticket
{
    public interface ITicketRepository : IReadOnlyRepository<Ticket>, IPersistanceRepository<Ticket>
    {
        public ICollection<Ticket> FindForProject(Guid projectId);
    }
}
