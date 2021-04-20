using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.projectUserRequests
{
    interface IProjectUsersRequests : IReadOnlyRepository<ProjectUserReq>, IPersistanceRepository<ProjectUserReq>
    {
    }
}
