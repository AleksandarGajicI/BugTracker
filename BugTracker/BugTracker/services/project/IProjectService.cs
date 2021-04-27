using BugTracker.contracts.requests.project;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.project
{
    public interface IProjectService
    {
        public CreateResponse<ProjectDTO> Create(CreateProjectRequest req);

        public DeleteResponse Delete(DeleteRequest req);

        public FindAllResponse<ProjectAbbreviatedDTO> FindAll();

        public FindByIdResponse<ProjectDTO> FindById(FindByIdRequest req);

        public FindPageResponse<ProjectAbbreviatedDTO> FindPage(FindPageRequest req);

        public UpdateResponse<ProjectDTO> Update(UpdateProjectRequest req);
    }
}
