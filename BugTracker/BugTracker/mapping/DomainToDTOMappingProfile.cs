using AutoMapper;
using BugTracker.contracts.requests.ticket;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.dto.ProjectUserReq;
using BugTracker.dto.ticket;
using BugTracker.model;
using System.Linq;

namespace BugTracker.mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<User, UserAbbreviatedDTO>();

            CreateMap<Role, RoleDTO>();
            CreateMap<Project, ProjectAbbreviatedDTO>();

            IncludeProjectUserReqMapping();

            IncludeProjectMapping();

            CreateMap<TicketStatus, TicketStatusDTO>();

            IncludeTicketMapping();

            CreateMap<TicketHistory, TicketHistoryDTO>();

        }

        private void IncludeTicketMapping()
        {
            CreateMap<Ticket, TicketAbbreviatedDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Status));

            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Reporter, opt => opt.MapFrom(src => src.Reporter.UserAssigned))
                .ForMember(dest => dest.RecentComments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
            CreateMap<Ticket, TicketForProjectDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Status))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));

            //CreateMap<Ticket, TicketDTO>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Status))

            CreateMap<CreateTicketRequest, Ticket>();

            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.Commenter, opt => opt.MapFrom(src => src.Commenter.UserAssigned));
        }

        private void IncludeProjectMapping()
        {
            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.RecentTickets, opt => opt.MapFrom(src => src.Tickets))
                .ForMember(dest => dest.UsersOnProject,
                            opt => opt.MapFrom(src => src.ProjectUsersReq.Where(x => x.Accepted == true)))
                .ForMember(dest => dest.PendingRequests,
                            opt => opt.MapFrom(src => src.ProjectUsersReq.Where(x => x.Accepted == false)));

        }

        private void IncludeProjectUserReqMapping()
        {
            CreateMap<ProjectUserReq, ProjectUserDTO>()
                .ForMember(dest => dest.InvitedBy, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserAssigned.UserName))
                .ForMember(dest => dest.InvitedAt, opt => opt.MapFrom(src => src.RequestSent));

            CreateMap<ProjectUserReq, ProjectUserRequestDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.InvitedAt, opt => opt.MapFrom(src => src.RequestSent));

        }
    }
}
