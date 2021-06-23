using BugTracker.contracts.requests.filterAndOrdering;
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
        public CreateResponse<ProjectDTO> Create(string id, CreateProjectRequest req);

        public DeleteResponse Delete(string userId, Guid id);

        public FindAllResponse<ProjectAbbreviatedDTO> FindAll(Guid id);

        public FindByIdResponse<ProjectDTO> FindById(Guid id);

        public UpdateResponse<ProjectDTO> Update(string userId, Guid id, UpdateProjectRequest req);

        public PagedResponse<ProjectAbbreviatedDTO> FindPage(string id, PagedQuery pagedQuery, FilterAndOrderQuery filterAndOrder);
    }
}
