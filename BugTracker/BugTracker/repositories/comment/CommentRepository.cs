using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.repositories.comment
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BugTrackerDatabase context, IUnitOfWork uow) : base(context, uow)
        { }

        public ICollection<Comment> findCommentsForTicket(Guid id)
        {
            return _table
                .Include(c => c.Commenter)
                    .ThenInclude(pur => pur.UserAssigned)
                .Where(c => c.Ticket.Id.Equals(id))
                .ToList();
        }
    }
}
