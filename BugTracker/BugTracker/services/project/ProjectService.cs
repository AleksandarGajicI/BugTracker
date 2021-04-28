using AutoMapper;
using BugTracker.contracts.requests.project;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.helpers;
using BugTracker.helpers.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;
using BugTracker.repositories.project;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.services.project
{
    public class ProjectService : IProjectService
    {

        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

            public CreateResponse<ProjectDTO> Create(CreateProjectRequest req)
        {
            throw new NotImplementedException();
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
