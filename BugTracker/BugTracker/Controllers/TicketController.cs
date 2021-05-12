﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.contracts;
using BugTracker.contracts.requests.ticket;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.services.ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetById(FindByIdRequest req)
        {
            var res = _ticketService.GetById(req);
            if (!res.Success)
            {
                BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet]
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
