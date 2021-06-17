using BugTracker.contracts;
using BugTracker.contracts.requests.ticket;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.ticket;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var res = _ticketService.Create(req);

            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
