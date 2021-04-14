using BugTracker.model;
using BugTracker.repositories.project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private Dictionary<Guid, Project> Projects = new Dictionary<Guid, Project>();

        public void AddProject(Project project)
        {
            Projects.Add(project.Id, project);
        }

        public void DeleteProject(Guid id)
        {
            return;
        }

        public Project FindProjectById(Guid id)
        {
            return null;
        }

        public List<Project> FindProjectForOwner(Guid ownerId)
        {
            return null;
        }

        public List<Project> GetAllProjects()
        {
            return Projects.Select(d => d.Value).ToList();
        }

        public void UpdateProject(Project project)
        {
            return;
        }
    }
}
