using System.Collections.Generic;
using BugTracker.model;
using BugTracker.repositories.project;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects() 
        {
            return projectRepository.GetAllProjects();
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project project) 
        {

            projectRepository.AddProject(project);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id) 
        {
            if (projectRepository.FindProjectById(id) is null) 
            {
                return NotFound();
            }

            projectRepository.DeleteProject(id);
            return Ok();
        }
    }
}
