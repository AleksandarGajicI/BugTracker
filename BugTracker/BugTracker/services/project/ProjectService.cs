using BugTracker.contracts.requests.project;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.project
{
    public class ProjectService : IProjectService
    {
        public CreateResponse<ProjectDTO> Create(CreateProjectRequest req)
        {
            throw new NotImplementedException();
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            throw new NotImplementedException();
        }

        public FindAllResponse<ProjectDTO> FindAll()
        {
            throw new NotImplementedException();
        }

        public FindByIdResponse<ProjectAbbreviatedDTO> FindById(FindByIdRequest req)
        {
            throw new NotImplementedException();
        }

        public FindPageResponse<ProjectDTO> FindPage(FindPageRequest req)
        {
            throw new NotImplementedException();
        }

        public UpdateResponse<ProjectDTO> Update(UpdateProjectRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
