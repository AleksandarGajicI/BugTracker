using BugTracker.contracts;
using BugTracker.contracts.requests.filterAndOrdering;
using BugTracker.contracts.requests.ticket;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.ticket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BugTracker.Controllers
{
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Route(ApiRoutes.Tickets.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

        [HttpGet]
        [Route(ApiRoutes.Tickets.GetById)]
        public IActionResult GetById(Guid id)
        {
            var res = _ticketService.GetById(id);
            if (!res.Success)
            {
                BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost]
        [Route(ApiRoutes.Tickets.Create)]
        public IActionResult Create(CreateTicketRequest req)
        {
            var id = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _ticketService.Create(Guid.Parse(id), req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route(ApiRoutes.Tickets.GetAllForProject)]
        public IActionResult GetForProject(Guid id) 
        {
            return Ok(_ticketService.GetAllForProject(id));
        }

        [HttpGet]
        [Route(ApiRoutes.Tickets.Page)]
        public IActionResult GetPage([FromQuery] PagedQuery pageQuery, [FromQuery] FilterAndOrderQuery filterAndOrderQuery)
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            return Ok(_ticketService.FindPage(userId, pageQuery, filterAndOrderQuery));
        }

        [HttpPut]
        [Route(ApiRoutes.Tickets.Update)]
        public IActionResult update(Guid id, UpdateTicketRequest req) 
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _ticketService.Update(id, Guid.Parse(userId), req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);

        }

        [HttpDelete]
        [Route(ApiRoutes.Tickets.Delete)]
        public IActionResult Delete(Guid id) 
        {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var res = _ticketService.Delete(Guid.Parse(userId), id);

            return NoContent();
        }
    }
}
