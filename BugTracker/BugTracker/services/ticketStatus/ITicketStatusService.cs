using BugTracker.dto;
using BugTracker.infrastructure.contracts.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.ticketStatus
{
    public interface ITicketStatusService
    {
        public FindAllResponse<TicketStatusDTO> GetAll();
    }
}
