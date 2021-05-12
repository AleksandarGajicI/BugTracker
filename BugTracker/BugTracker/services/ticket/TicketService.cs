using AutoMapper;
using BugTracker.contracts.requests.ticket;
using BugTracker.dto.ticket;
using BugTracker.helpers;
using BugTracker.helpers.ticket;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.model.domainServices;
using BugTracker.repositories.project;
using BugTracker.repositories.projectUserRequests;
using BugTracker.repositories.ticket;
using BugTracker.repositories.ticketStatus;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;
using static BugTracker.model.Ticket;

namespace BugTracker.services.ticket
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRepository _ticketRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProjectUserReqRepository _projectUserReqRepository;
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly TicketDomainService _ticketDomainService = new TicketDomainService();

        public TicketService(ITicketRepository ticketRepository,
                                IProjectRepository projectRepository,
                                IUserRepository userRepository,
                                IProjectUserReqRepository projectUserReqRepository,
                                ITicketStatusRepository ticketStatusRepository,
                                IUnitOfWork uow,
                                IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _projectUserReqRepository = projectUserReqRepository;
            _ticketStatusRepository = ticketStatusRepository;
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


        public CreateResponse<TicketDTO> Create(CreateTicketRequest req)
        {
            var res = new CreateResponse<TicketDTO>();

            var project = _projectRepository.FindById(req.ProjectId);

            if (project == null)
            {
                return (CreateResponse<TicketDTO>)
                    res.ReturnErrorResponseWith("Specified project doesn't exist");
            }

            var user = _userRepository.FindById(req.ReporterId);

            if (user == null)
            {
                return (CreateResponse<TicketDTO>)
                    res.ReturnErrorResponseWith("Specified user doesn't exist");
            }

            var projectUser = _projectUserReqRepository
                                .FindProjectUserFor(user.Id, project.Id);

            if (projectUser == null)
            {
                return (CreateResponse<TicketDTO>)
                    res.ReturnErrorResponseWith("Only users on projects can make new tickets");
            }

            var ticketStatus = _ticketStatusRepository.FindById(req.StatusId);

            if (ticketStatus == null)
            {
                return (CreateResponse<TicketDTO>)
                    res.ReturnErrorResponseWith("Specified ticket status doesn't exist");
            }

            var ticketType = req.TicketType == null ? 
                            TicketType.UNDEFINED : 
                            req.TicketType.ConvertToTicketType();

            var ticket = _mapper.Map<CreateTicketRequest, Ticket>(req);

            ticket.Reporter = projectUser;
            ticket.Project = project;
            ticket.Status = ticketStatus;
            ticket.Created = DateTime.Now;

            ticket.Validate();

            if (ticket.GetBrokenRules().Count > 0)
            {
                return (CreateResponse<TicketDTO>)
                        res.ReturnErrorResponseWithMultiple(ticket.GetBrokenRules());
            }

            _ticketRepository.Save(ticket);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (CreateResponse<TicketDTO>)
                        res.ReturnErrorResponseWith(ex.Message);
            }


            res.Success = true;
            res.EntityDTO = _mapper.Map<Ticket, TicketDTO>(ticket);

            return res;
        }

        public DeleteResponse Delete(Guid id)
        {
            var res = new DeleteResponse();

            var ticket = _ticketRepository.FindById(id);

            if (ticket == null)
            {
                return (DeleteResponse)res.ReturnErrorResponseWith("Ticket not found");
            }

            _ticketRepository.Delete(ticket);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (DeleteResponse)res.ReturnErrorResponseWith(ex.Message); 
            }

            res.IdDeleted = ticket.Id;
            res.Success = true;

            return res;
        }

        public UpdateResponse<TicketDTO> Update(Guid id, UpdateTicketRequest req)
        {
            var res = new UpdateResponse<TicketDTO>();

            var type = req.Type.ConvertToTicketType();

            var ticket = _ticketRepository.FindById(id);

            if (ticket == null)
            {
                return (UpdateResponse<TicketDTO>)res.ReturnErrorResponseWith("Ticket not found");
            }

            var user = _userRepository.FindById(req.UserId);

            if (user == null)
            {
                return (UpdateResponse<TicketDTO>)
                            res.ReturnErrorResponseWith("User not found");
            }

            var histories = _ticketDomainService
                                .GetHistoriesFor(ticket,
                                                 user,
                                                 req.Title,
                                                 req.Description,
                                                 req.Deadline,
                                                 type);


            if (type != TicketType.UNDEFINED)
            {
                ticket.Type = type;
            }


            ticket.Title = req.Title;
            ticket.Description = req.Description;
            ticket.Deadline = req.Deadline;

            ticket.Validate();

            if (ticket.GetBrokenRules().Count > 0)
            {
                return (UpdateResponse<TicketDTO>)
                            res.ReturnErrorResponseWithMultiple(ticket.GetBrokenRules());
            }

            ticket.Updated = DateTime.Now;

            foreach(var history in histories) 
            { 
                //TODO save all history
            }

            _ticketRepository.Save(ticket);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (UpdateResponse<TicketDTO>)
                            res.ReturnErrorResponseWith(ex.Message);
            }

            res.EntityDTO = _mapper.Map<Ticket, TicketDTO>(ticket);
            res.Success = true;

            return res;
        }
    }
}
