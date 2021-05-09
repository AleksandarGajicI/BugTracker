using BugTracker.contracts.requests.ticket;
using BugTracker.dto.ticket;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;

namespace BugTracker.services.ticket
{
    public interface ITicketService
    {
        public FindAllResponse<TicketAbbreviatedDTO> GetAll();
        public FindByIdResponse<TicketDTO> GetById(FindByIdRequest req);

        public PagedResponse<TicketAbbreviatedDTO> FindPage();

        public CreateResponse<TicketDTO> Create(CreateTicketRequest req);
    }
}
