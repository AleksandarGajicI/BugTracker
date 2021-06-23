using BugTracker.contracts;
using BugTracker.contracts.requests.filterAndOrdering;
using BugTracker.contracts.requests.user;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.user;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        [HttpPost]
        [Route(ApiRoutes.Users.Register)]
        [AllowAnonymousAttribute]
        public IActionResult Register([FromBody] RegisterUserRequest req)
        {
            var res = _userService.Create(req);

            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpDelete]
        [Route(ApiRoutes.Users.Delete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete([FromBody] DeleteRequest req)
        {
            

            var httpUser = HttpContext.User;

            if (httpUser == null)
            {
                return Unauthorized();
            }

            var claim = httpUser.Claims.Single(x => x.Type == "Id");

            var id = claim.Value;

            var res = _userService.Delete(req, id);

            if (!res.Success)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPost]
        [Route(ApiRoutes.Users.Login)]
        [AllowAnonymousAttribute]
        public IActionResult Login(LoginRequest req)
        {
            var res = _userService.Login(req);

            
            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpGet]
        [Route(ApiRoutes.Users.Page)]
        public IActionResult GetPage([FromQuery] PagedQuery pageQuery, [FromQuery] FilterAndOrderQuery filterAndOrderQuery)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _userService.GetPage(userId, pageQuery, filterAndOrderQuery);


            if (!res.Success)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }
    }
}
