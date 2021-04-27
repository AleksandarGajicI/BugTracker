using AutoMapper;
using BugTracker.dto;
using BugTracker.dto.project;
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


            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.UsersOnProject, 
                            opt => opt.MapFrom(src => src.ProjectUsersReq.Where(x => x.Accepted == true)));
        }
    }
}
