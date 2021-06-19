﻿using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.repositories.projectUserRequests
{
    public class ProjectUserReqRepository : GenericRepository<ProjectUserReq>, IProjectUserReqRepository
    {
        public ProjectUserReqRepository(BugTrackerDatabase context, IUnitOfWork uof)
            : base(context, uof)
        {
        }

        public override IEnumerable<ProjectUserReq> FindAll()
        {
            return _table
                .Include(pur => pur.Sender)
                .Include(pur => pur.Role)
                .Include(pur => pur.UserAssigned)
                .Include(pur => pur.Project)
                .ToList();
        }



        public override ProjectUserReq FindById(Guid id)
        {
            return _table.Where(pur => pur.Id == id)
                .Include(pur => pur.Sender)
                .Include(pur => pur.Role)
                .Include(pur => pur.UserAssigned)
                .FirstOrDefault();
        }

        public ProjectUserReq FindProjectUserFor(Guid userId, Guid projectId)
        {
            return _table.Where(uop => uop.UserAssignedId == userId &&
                                uop.ProjectId == projectId)
                         .FirstOrDefault();
        }
    }
}
