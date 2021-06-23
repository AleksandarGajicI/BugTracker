
using BugTracker.contracts;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.services.role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BugTracker.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [AllowAnonymousAttribute]
        [Route(ApiRoutes.Roles.GetAll)]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleService.FindAll());
        }

        [HttpGet]
        [Route(ApiRoutes.Roles.GetById)]
        public IActionResult GetRoleById([FromBody] FindByIdRequest req)
        {
            FindByIdResponse<RoleDTO> res = _roleService.FindById(req);

            if (!res.Success)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

    }
}
