using AutoMapper;
using BugTracker.dto.ticket;
using BugTracker.helpers;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.ticket
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, 
                                IUnitOfWork uow,
                                IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _uow = uow;
            _mapper = mapper;
        }
        public PagedResponse<TicketAbbreviatedDTO> FindPage()
        {
            throw new NotImplementedException();
        }

        public FindAllResponse<TicketAbbreviatedDTO> GetAll()
        {
            var res = new FindAllResponse<TicketAbbreviatedDTO>();

            var tickets = _ticketRepository.FindAll();

            res.Success = true;
            res.FoundEntitiesDTO = 
                _mapper.Map<ICollection<Ticket>, ICollection<TicketAbbreviatedDTO>>(tickets.ToList());
            return res;
        }

        public FindByIdResponse<TicketDTO> GetById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<TicketDTO>();
            var ticket = _ticketRepository.FindById(req.Id);

            if (ticket == null)
            {
                return (FindByIdResponse<TicketDTO>)res.ReturnErrorResponseWith("Ticket not found");
            }

            res.Success = true;
            res.EntityDTO = _mapper.Map<Ticket, TicketDTO>(ticket);
            return res;
        }
    }
}
