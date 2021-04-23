using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.contracts;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.user;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route(ApiRoutes.Users.GetAll)]
        public IActionResult GetAllUsers()
        {
            var res = _userService.FindAll();

            if (res.FoundEntitiesDTO is null || res.FoundEntitiesDTO.Count == 0)
            {
                return NotFound();
            }

            return Ok(res);
        }
        [HttpGet]
        [Route(ApiRoutes.Users.GetById)]
        public IActionResult GetUserById(FindByIdRequest req)
        {
            var res = _userService.FindById(req);

            if (res.Errors is null || res.Errors.Count > 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }
    }
}
