using BugTracker.contracts.requests.ticket;
using BugTracker.dto.ticket;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using System;

namespace BugTracker.services.ticket
{
    public interface ITicketService
    {
        public FindAllResponse<TicketAbbreviatedDTO> GetAll();
        public FindByIdResponse<TicketDTO> GetById(Guid id);

        public PagedResponse<TicketAbbreviatedDTO> FindPage();

        public CreateResponse<TicketDTO> Create(CreateTicketRequest req);

        public DeleteResponse Delete(Guid id);

        public UpdateResponse<TicketDTO> Update(Guid id, UpdateTicketRequest req);
    }
}
