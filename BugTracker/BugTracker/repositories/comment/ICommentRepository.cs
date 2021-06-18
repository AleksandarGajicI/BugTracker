using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.comment
{
    public interface ICommentRepository : IPersistanceRepository<Comment>, IReadOnlyRepository<Comment>
    {
        public ICollection<Comment> findCommentsForTicket(Guid id);
    }
}
