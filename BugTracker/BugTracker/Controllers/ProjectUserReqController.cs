using BugTracker.contracts;
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
    }
}
