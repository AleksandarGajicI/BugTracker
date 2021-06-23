using BugTracker.contracts;
using BugTracker.contracts.requests.projectUserReq;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.projectUserReq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BugTracker.Controllers
{
    [ApiController]
    public class ProjectUserReqController : ControllerBase
    {

        private readonly IProjectUserReqService _projectUserReqService;

        public ProjectUserReqController(IProjectUserReqService projectUserReqService)
        {
            _projectUserReqService = projectUserReqService;
        }

        [HttpGet]
        [Route(ApiRoutes.ProjectUserReq.GetAll)]
        public IActionResult GetAll()
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            return Ok(_projectUserReqService.GetAll(Guid.Parse(userId)));
        }

        [HttpGet]
        [Route(ApiRoutes.ProjectUserReq.GetAllSent)]
        public IActionResult GetAllSent()
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            return Ok(_projectUserReqService.GetAllSentReq(Guid.Parse(userId)));
        }

        [HttpPost]
        [Route(ApiRoutes.ProjectUserReq.Create)]
        public IActionResult CreateRequest(CreateProjectUserReqRequest req)
        {

            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _projectUserReqService.Create(Guid.Parse(userId), req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route(ApiRoutes.ProjectUserReq.Reply)]
        public IActionResult ReplyRequest(ProjectUserReplyRequest req)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;


            var res = _projectUserReqService.ReplyWith(Guid.Parse(userId), req);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route(ApiRoutes.ProjectUserReq.Delete)]
        public IActionResult Delete(Guid id)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _projectUserReqService.Delete(Guid.Parse(userId), id);

            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

    }
}
