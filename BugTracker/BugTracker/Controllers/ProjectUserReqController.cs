using BugTracker.contracts;
using BugTracker.contracts.requests.projectUserReq;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.projectUserReq;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_projectUserReqService.GetAll());
        }

        [HttpPost]
        [Route(ApiRoutes.ProjectUserReq.Create)]
        public IActionResult CreateRequest(CreateProjectUserReqRequest req)
        {
            var res = _projectUserReqService.Create(req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPatch]
        [Route(ApiRoutes.ProjectUserReq.Reply)]
        public IActionResult ReplyRequest(ProjectUserReplyRequest req)
        {
            var res = _projectUserReqService.ReplyWith(req);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route(ApiRoutes.ProjectUserReq.Delete)]
        public IActionResult Delete(DeleteRequest req)
        {
            var res = _projectUserReqService.Delete(req);

            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

    }
}
