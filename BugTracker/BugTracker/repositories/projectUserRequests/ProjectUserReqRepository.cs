using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.projectUserRequests
{
    public class ProjectUserReqRepository : GenericRepository<ProjectUserReq>, IProjectUsersRequests
    {
        public ProjectUserReqRepository(BugTrackerDatabase context, IUnitOfWork uof)
            : base(context, uof)
            {
            }
    }
}
