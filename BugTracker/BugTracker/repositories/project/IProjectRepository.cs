using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.project
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjects();
        Project FindProjectById(Guid id);

        List<Project> FindProjectForOwner(Guid ownerId);

        void AddProject(Project project);

        void DeleteProject(Guid id);

        void UpdateProject(Project project);
    }
}
