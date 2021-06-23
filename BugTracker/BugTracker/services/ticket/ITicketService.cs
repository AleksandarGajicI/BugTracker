using BugTracker.contracts.requests.filterAndOrdering;
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
        public FindAllResponse<TicketForProjectDTO> GetAllForProject(Guid projectId);
        public FindByIdResponse<TicketDTO> GetById(Guid id);

        public PagedResponse<TicketAbbreviatedDTO> FindPage(string userId, PagedQuery pageQuery, FilterAndOrderQuery filterAndOrderQuery);

        public CreateResponse<TicketDTO> Create(Guid id, CreateTicketRequest req);

        public DeleteResponse Delete(Guid userId, Guid id);

        public UpdateResponse<TicketDTO> Update(Guid id, Guid userId, UpdateTicketRequest req);
    }
}
