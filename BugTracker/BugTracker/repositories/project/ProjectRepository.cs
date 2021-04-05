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
        private Dictionary<int, Project> Projects = new Dictionary<int, Project>();

        public void AddProject(Project project)
        {
            Projects.Add(project.ProjectId, project);
        }

        public void DeleteProject(int id)
        {
            Projects.Remove(id);
        }

        public Project FindProjectById(int id)
        {
            return Projects.ContainsKey(id) ? Projects[id] : null;
        }

        public List<Project> FindProjectForOwner(int ownerId)
        {
            return Projects.Where(d => d.Value.owner.UserId == ownerId)
                 .Select(d => d.Value).ToList();
        }

        public List<Project> GetAllProjects()
        {
            return Projects.Select(d => d.Value).ToList();
        }

        public void UpdateProject(Project project)
        {
            Projects[project.ProjectId] = project;
        }
    }
}
