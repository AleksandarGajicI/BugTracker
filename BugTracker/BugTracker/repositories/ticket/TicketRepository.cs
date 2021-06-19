using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace BugTracker.repositories.ticket
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(BugTrackerDatabase context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public override IEnumerable<Ticket> FindAll()
        {
            return _table.Include(t => t.Status).ToList();
        }
        public override Ticket FindById(Guid id)
        {
            return _table
                .Include(t => t.Project)
                .Include(t => t.Comments)
                .Include(t => t.Status)
                .Include(t => t.Reporter)
                    .ThenInclude(pur => pur.UserAssigned)
                .Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<Ticket> FindForProject(Guid projectId)
        {
            return _table
                .Include(t => t.Status)
                .Where(t => t.Project.Id.Equals(projectId)).ToList();
        }
    }
}
