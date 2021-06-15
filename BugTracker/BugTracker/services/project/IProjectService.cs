﻿using BugTracker.contracts.requests.filterAndOrdering;
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

        public DeleteResponse Delete(Guid id);

        public FindAllResponse<ProjectAbbreviatedDTO> FindAll();

        public FindByIdResponse<ProjectDTO> FindById(Guid id);

        public UpdateResponse<ProjectDTO> Update(Guid id, UpdateProjectRequest req);

        public PagedResponse<ProjectAbbreviatedDTO> FindPage(PagedQuery pagedQuery, FilterAndOrderQuery filterAndOrder);
    }
}
