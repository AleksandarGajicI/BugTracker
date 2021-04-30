using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.repositories.projectUserRequests
{
    public class ProjectUserReqRepository : GenericRepository<ProjectUserReq>, IProjectUserReqRepository
    {
        public ProjectUserReqRepository(BugTrackerDatabase context, IUnitOfWork uof)
            : base(context, uof)
        {
        }

        public override IEnumerable<ProjectUserReq> FindAll()
        {
            return _table
                .Include(pur => pur.Sender)
                .Include(pur => pur.Role)
                .Include(pur => pur.UserAssigned)
                .ToList();
        }
    }
}
