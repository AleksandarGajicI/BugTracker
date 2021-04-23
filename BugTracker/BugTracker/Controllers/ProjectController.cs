using System;
using System.Collections.Generic;
using BugTracker.contracts.requests.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.model;
using BugTracker.repositories.project;
using BugTracker.services.project;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects() 
        {
            return null;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] CreateProjectRequest project) 
        {
            _projectService.Create(project);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(DeleteRequest req) 
        {
            _projectService.Delete(req);
            return Ok();
        }
    }
}
