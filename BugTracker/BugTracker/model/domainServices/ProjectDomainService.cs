using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model.domainServices
{
    public class ProjectDomainService : IProjectDomainService
    {
        public Project CreateProject(User owner, string projectName, string description, DateTime deadline, Role role)
        {
            Project project = new Project(
                projectName,
                description,
                deadline);

            ProjectUserReq req = new ProjectUserReq(
                "Automatic assignement",
                owner,
                role,
                project);

            req.Sender = owner;

            project.AddUserToProject(req);

            return project;
        }
    }
}
