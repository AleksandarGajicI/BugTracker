using System;
using System.Collections.Generic;
using BugTracker.contracts;
using BugTracker.contracts.requests.filterAndOrdering;
using BugTracker.contracts.requests.project;
using BugTracker.helpers.uri;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.model;
using BugTracker.repositories.project;
using BugTracker.services.project;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IUriService _uriService;

        public ProjectController(IProjectService projectService, IUriService uriService)
        {
            _projectService = projectService;
            _uriService = uriService;
        }

        [HttpGet]
        [Route(ApiRoutes.Projects.GetAll)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route(ApiRoutes.Projects.Delete)]
        public IActionResult DeleteProject(DeleteRequest req) 
        {
            var res =_projectService.Delete(req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route(ApiRoutes.Projects.GetPage)]
        public IActionResult GetPage([FromQuery] PagedQuery pageQuery,[FromQuery] FilterAndOrderQuery filterAndOrderQuery)
        {
            var res = _projectService.FindPage(pageQuery, filterAndOrderQuery);

            var pageNum = (int)pageQuery.PageNum;
            var pageSize = (int)pageQuery.PageSize;

            var nextPage = pageNum >= 1 ?
                _uriService.GetAllUri(new PagedQuery(pageSize, pageNum + 1)).ToString() :
                null;

            var prevPage = pageQuery.PageNum - 1 >= 1 ?
                _uriService.GetAllUri(new PagedQuery(pageSize, pageNum - 1)).ToString() :
                null;

            res.NextPage = nextPage;
            res.PrevPage = prevPage;

            return Ok(res);
        }
    }
}
