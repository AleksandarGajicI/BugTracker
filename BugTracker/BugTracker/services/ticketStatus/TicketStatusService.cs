using AutoMapper;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;
using BugTracker.repositories.ticketStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.ticketStatus
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly IMapper _mapper;

        public TicketStatusService(ITicketStatusRepository ticketStatusRepository, IMapper mapper)
        {
            _ticketStatusRepository = ticketStatusRepository;
            _mapper = mapper;
        }

        public FindAllResponse<TicketStatusDTO> GetAll()
        {
            var res = new FindAllResponse<TicketStatusDTO>();

            var ticketStatuses = _ticketStatusRepository.FindAll();

            res.FoundEntitiesDTO = 
                _mapper.Map<ICollection<TicketStatus>, ICollection<TicketStatusDTO>>(ticketStatuses.ToList());
            res.Success = true;
            return res;
        }
    }
}
