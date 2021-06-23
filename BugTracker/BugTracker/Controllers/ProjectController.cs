using BugTracker.contracts;
using BugTracker.contracts.requests.filterAndOrdering;
using BugTracker.contracts.requests.project;
using BugTracker.helpers.uri;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.project;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        public IActionResult GetProjects()
        {
            var id = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _projectService.FindAll(Guid.Parse(id));
            return Ok(res);
        }

        [HttpGet]
        [Route(ApiRoutes.Projects.GetById)]
        public IActionResult GetProjectById(Guid id)
        {
            var res = _projectService.FindById(id);

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
            var id = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _projectService.Create(id, project);

            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpPut]
        [Route(ApiRoutes.Projects.Update)]
        public IActionResult UpdateProject(Guid id, [FromBody] UpdateProjectRequest req)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _projectService.Update(userId, id, req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route(ApiRoutes.Projects.Delete)]
        public IActionResult DeleteProject(Guid id)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _projectService.Delete(userId, id);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route(ApiRoutes.Projects.GetPage)]
        public IActionResult GetPage([FromQuery] PagedQuery pageQuery, [FromQuery] FilterAndOrderQuery filterAndOrderQuery)
        {

            var httpUser = HttpContext.User;

            var claim = httpUser.Claims.Single(x => x.Type == "Id");

            var id = claim.Value;

            var res = _projectService.FindPage(id, pageQuery, filterAndOrderQuery);

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
