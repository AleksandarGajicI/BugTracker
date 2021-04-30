﻿using BugTracker.dto.ProjectUserReq;
using BugTracker.infrastructure.contracts.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.projectUserReq
{
    public interface IProjectUserReqService
    {
        public FindAllResponse<ProjectUserRequestDTO> GetAll();
    }
}