using BugTracker.contracts;
using BugTracker.services.ticketStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly ITicketStatusService _ticketStatusService;

        public TicketStatusController(ITicketStatusService ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet]
        [AllowAnonymousAttribute]
        [Route(ApiRoutes.TicketStatus.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_ticketStatusService.GetAll());
        }
    }
}
