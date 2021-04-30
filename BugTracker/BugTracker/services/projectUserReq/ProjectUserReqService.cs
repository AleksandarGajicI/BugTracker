using AutoMapper;
using BugTracker.dto.ProjectUserReq;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;
using BugTracker.repositories.projectUserRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.projectUserReq
{
    public class ProjectUserReqService : IProjectUserReqService
    {
        private readonly IProjectUserReqRepository _projectUserReqRepository;
        private readonly IMapper _mapper;

        public ProjectUserReqService(IProjectUserReqRepository projectUserReqRepository, IMapper mapper)
        {
            _projectUserReqRepository = projectUserReqRepository;
            _mapper = mapper;
        }

        public FindAllResponse<ProjectUserRequestDTO> GetAll()
        {
            var res = new FindAllResponse<ProjectUserRequestDTO>();

            var requests = _projectUserReqRepository.FindAll();

            res.FoundEntitiesDTO = _mapper
                                    .Map<ICollection<ProjectUserReq>, ICollection<ProjectUserRequestDTO>>(requests.ToList());
            res.Success = true;
            return res;
        }
    }
}
