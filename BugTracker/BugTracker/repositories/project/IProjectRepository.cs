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
        Project FindProjectById(int id);

        List<Project> FindProjectForOwner(int ownerId);

        void AddProject(Project project);

        void DeleteProject(int id);

        void UpdateProject(Project project);
    }
}
