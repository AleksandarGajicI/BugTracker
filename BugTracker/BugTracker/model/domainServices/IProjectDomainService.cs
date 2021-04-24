using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model.domainServices
{
    public interface IProjectDomainService
    {
        public Project CreateProject(User owner, string projectName, string description, DateTime deadline, Role role);

    }
}
