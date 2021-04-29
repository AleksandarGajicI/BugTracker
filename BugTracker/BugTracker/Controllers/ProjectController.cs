using System;
using System.Collections.Generic;
using BugTracker.contracts;
using BugTracker.contracts.requests.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.model;
using BugTracker.repositories.project;
using BugTracker.services.project;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route(ApiRoutes.Projects.GetAll)]
        public IActionResult GetProjects() 
        {
            var res = _projectService.FindAll();
            return Ok(res);
        }

        [HttpGet]
        [Route(ApiRoutes.Projects.GetById)]
        public IActionResult GetProjectById([FromBody] FindByIdRequest req)
        {
            var res = _projectService.FindById(req);

            if (!res.Success)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [HttpPost]
        [Route(ApiRoutes.Projects.Create)]
        public IActionResult AddProject([FromBody] CreateProjectRequest project) 
        {
            var res = _projectService.Create(project);

            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok();
        }

        [HttpPut]
        [Route(ApiRoutes.Projects.Update)]
        public IActionResult UpdateProject([FromBody]UpdateProjectRequest req)
        {
            var res = _projectService.Update(req);
            return Ok();
        }

        [HttpDelete]
        [Route(ApiRoutes.Projects.Delete)]
        public IActionResult DeleteProject(DeleteRequest req) 
        {
            _projectService.Delete(req);
            return Ok();
        }
    }
}
