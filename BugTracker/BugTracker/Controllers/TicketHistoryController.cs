using AutoMapper;
using BugTracker.contracts;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;
using BugTracker.repositories.ticketHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BugTracker.Controllers
{
    [ApiController]
    public class TicketHistoryController : ControllerBase
    {
        private readonly ITicketHistoryRepository _ticketHistoryRepository;
        private readonly IMapper _mapper;


        public TicketHistoryController(ITicketHistoryRepository ticketHistoryRepository,
                                        IMapper mapper)
        {
            _ticketHistoryRepository = ticketHistoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoutes.TicketHistories.GetByTicketId)]
        public IActionResult getByTicketId(Guid id)
        {
            var res = new FindAllResponse<TicketHistoryDTO>();
            res.Success = true;
            res.FoundEntitiesDTO =
                _mapper
                .Map<ICollection<TicketHistory>, ICollection<TicketHistoryDTO>>(_ticketHistoryRepository.FindHistoryForTicket(id));
            return Ok(res);
        }
    }
}
