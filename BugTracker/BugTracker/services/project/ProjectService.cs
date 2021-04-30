using AutoMapper;
using BugTracker.contracts.requests.project;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.helpers;
using BugTracker.helpers.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.model.domainServices;
using BugTracker.repositories.project;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.services.project
{
    public class ProjectService : IProjectService
    {

        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ProjectDomainService _projectDomainService;

        public ProjectService(IProjectRepository projectRepository,
                                IUserRepository userRepository,
                                IRoleRepository roleRepository,
                                IUnitOfWork uow , 
                                IMapper mapper)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _uow = uow;
            _mapper = mapper;
            _projectDomainService = new ProjectDomainService();

        }

        public CreateResponse<ProjectDTO> Create(CreateProjectRequest req)
        {
            var res = new CreateResponse<ProjectDTO>();

            var user = _userRepository.FindById(req.OwnerId);

            if (user == null)
            {
                return (CreateResponse<ProjectDTO>) res.ReturnErrorResponseWith("User not found.");
            }

            var role = _roleRepository.FindRoleByName("PROJECT_MANAGER");

            if (role == null)
            {
                return (CreateResponse<ProjectDTO>) res.ReturnErrorResponseWith("Error ocurred during asigning roles");
            }

            var project = _projectDomainService.CreateProject(user,
                                                              req.Name,
                                                              req.Description,
                                                              req.Deadline,
                                                              role);



            project.Validate();

            if (project.GetBrokenRules().Count > 0)
            {
                return (CreateResponse<ProjectDTO>) res.ReturnErrorResponseWithMultiple(project.GetBrokenRules());
            }

            _projectRepository.Save(project);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (CreateResponse<ProjectDTO>) res.ReturnErrorResponseWith(ex.Message);
            }

            res.Success = true;
            res.EntityDTO = _mapper.Map<Project, ProjectDTO>(project);
            return res;
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            var res = new DeleteResponse();

            var project = _projectRepository.FindById(req.Id);

            if (project == null)
            {
                return (DeleteResponse) res.ReturnErrorResponseWith("Project not found.");
            }

            _projectRepository.Delete(project);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (DeleteResponse) res.ReturnErrorResponseWith(ex.Message);
            }

            res.Success = true;
            res.IdDeleted = project.Id;
            return res;
        }

        public FindAllResponse<ProjectAbbreviatedDTO> FindAll()
        {
            var res = new FindAllResponse<ProjectAbbreviatedDTO>();
            var projects = _projectRepository.FindAll().ToList();
            res.FoundEntitiesDTO = 
                _mapper.Map<ICollection<Project>, ICollection<ProjectAbbreviatedDTO>>(projects);
            res.Success = true;
            return res;

        }

        public FindByIdResponse<ProjectDTO> FindById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<ProjectDTO>();

            var project = _projectRepository.FindById(req.Id);
            if (project is null)
            {
                return (FindByIdResponse<ProjectDTO>) res.ReturnErrorResponseWith("Project not found");
            }

            res.EntityDTO = _mapper.Map<Project, ProjectDTO>(project);
            res.Success = true;
            return res;
        }

        public FindPageResponse<ProjectAbbreviatedDTO> FindPage(FindPageRequest<ProjectFilterOptions, ProjectOrderOptions> req)
        {
            var res = new FindPageResponse<ProjectAbbreviatedDTO>();
            var query = _projectRepository.GetBasicQuery();

            foreach (var option in req.Filters)
            {
                query.ApplyFilterOption(option.Option, option.Value);
            }

            query.ApplySortingOptions(req.SortingOption)
                .Page(req.PageNum, req.PageSize);

            var projects = query.ToList();

            if (projects != null || projects.Count == 0)
            {
                return (FindPageResponse<ProjectAbbreviatedDTO>)
                    res.ReturnErrorResponseWith("Projects not found for query");
            }

            res.Success = true;
            res.EntitiesDTO = _mapper.Map<ICollection<Project>, ICollection<ProjectAbbreviatedDTO>>(projects);
            res.PageNum = req.PageNum;
            res.PageSize = req.PageSize;
            res.MaxPage = query.Count() / req.PageSize;
            return res;
        }

        public UpdateResponse<ProjectDTO> Update(UpdateProjectRequest req)
        {
            var res = new UpdateResponse<ProjectDTO>();

            var project = _projectRepository.FindById(req.Id);

            if (project == null)
            {
                return (UpdateResponse<ProjectDTO>)res.ReturnErrorResponseWith("Project not found");
            }

            var owners = project.ProjectUsersReq.Where(pur => pur.Role.RoleName == "PROJECT_MANAGER").ToList();

            if (owners.Find(pur => pur.Id == req.OwnerId) == null)
            {
                return (UpdateResponse<ProjectDTO>)res.ReturnErrorResponseWith("Only project managers can update projects!");
            }

            project.Name = req.Name;
            project.Description = req.Description;
            project.Closed = req.Closed;
            project.Deadline = req.Deadline;

            project.Validate();

            if (project.GetBrokenRules().Count > 0)
            {
                return (UpdateResponse<ProjectDTO>)res.ReturnErrorResponseWithMultiple(project.GetBrokenRules());
            }

            _projectRepository.Update(project);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (UpdateResponse<ProjectDTO>)res.ReturnErrorResponseWith(ex.Message);
            }

            res.Success = true;
            res.EntityDTO = _mapper.Map<Project, ProjectDTO>(project);
            return res;
        }
    }
}
