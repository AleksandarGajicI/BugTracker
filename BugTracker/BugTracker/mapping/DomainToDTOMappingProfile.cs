using AutoMapper;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.dto.ProjectUserReq;
using BugTracker.dto.ticket;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<Role, RoleDTO>();
            CreateMap<Project, ProjectAbbreviatedDTO>();

            CreateMap<ProjectUserReq, ProjectUserDTO>()
                .ForMember(dest => dest.InvitedBy, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserAssigned.UserName))
                .ForMember(dest => dest.InvitedAt, opt => opt.MapFrom(src => src.RequestSent));

            CreateMap<ProjectUserReq, ProjectUserRequestDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.InvitedBy, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserAssigned.UserName))
                .ForMember(dest => dest.InvitedAt, opt => opt.MapFrom(src => src.RequestSent))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Accepted));


            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.UsersOnProject, 
                            opt => opt.MapFrom(src => src.ProjectUsersReq.Where(x => x.Accepted == true)))
                .ForMember(dest => dest.PendingRequests,
                            opt => opt.MapFrom(src => src.ProjectUsersReq.Where(x => x.Accepted == false)));

            CreateMap<TicketStatus, TicketStatusDTO>();

            CreateMap<Ticket, TicketAbbreviatedDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Status));

            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Status))
                .ForMember(dest => dest.Reporter, opt => opt.MapFrom(src => src.Reporter.UserAssigned.UserName))
                .ForMember(dest => dest.RecentComments, opt => opt.MapFrom(src => src.Comments));
        }
    }
}
