using AutoMapper;
using BugTracker.contracts.requests.project;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;
using BugTracker.repositories.project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            res.Success = true;
            return res;
        }

        public FindPageResponse<ProjectAbbreviatedDTO> FindPage(FindPageRequest req)
        {
            throw new NotImplementedException();
        }

        public UpdateResponse<ProjectDTO> Update(UpdateProjectRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
