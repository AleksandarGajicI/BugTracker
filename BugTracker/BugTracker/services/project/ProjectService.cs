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
                res.Errors.Add("User not found");
                res.Success = false;
                return res;
            }

            var role = _roleRepository.FindRoleByName("PROJECT_MANAGER");

            if (role == null)
            {
                res.Errors.Add("Error ocurred during asigning roles");
                res.Success = false;
                return res;
            }

            Console.WriteLine("creating project... ");

            var project = _projectDomainService.CreateProject(user,
                                                              req.Name,
                                                              req.Description,
                                                              req.Deadline,
                                                              role);



            project.Validate();

            if (project.GetBrokenRules().Count > 0)
            {
                foreach (var brokenRule in project.GetBrokenRules())
                {
                    res.Errors.Add(brokenRule.Rule);
                }
                res.Success = false;
                return res;
            }

            foreach (var pur in project.ProjectUsersReq)
            {
                Console.WriteLine(pur.UserAssigned.UserName);
            }

            _projectRepository.Save(project);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                res.Errors.Add(ex.Message);
                res.Success = false;
                return res;
            }

            res.Success = true;
            res.EntityDTO = _mapper.Map<Project, ProjectDTO>(project);
            return res;
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            throw new NotImplementedException();
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
                res.Errors.Add("Project not found!");
                res.Success = false;
                return res;
            }

            //map Project to ProjectDTO
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
                res.Errors.Add("Not found!");
                res.Success = false;
                return res;
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
            throw new NotImplementedException();
        }
    }
}
