using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.projectUserRequests
{
    public interface IProjectUserReqRepository : IReadOnlyRepository<ProjectUserReq>, IPersistanceRepository<ProjectUserReq>
    {
    }
}
