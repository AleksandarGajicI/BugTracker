using BugTracker.contracts.requests.project;
using BugTracker.dto;
using BugTracker.dto.project;
using BugTracker.infrastructure.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.project
{
    public interface IProjectService : IService<ProjectDTO, ProjectAbbreviatedDTO, CreateProjectRequest, UpdateProjectRequest>
    {

    }
}
