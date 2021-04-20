using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.project
{
    public interface IProjectRepository : IReadOnlyRepository<Project>, IPersistanceRepository<Project>
    {
        public IEnumerable<Project> findProjectWithDeadlineBefore(DateTime deadline);
    }
}
