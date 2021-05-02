using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.project;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.repositories.project
{
    public class ProjectRepository : GenericRepository<Project>,  IProjectRepository
    {
        public ProjectRepository(BugTrackerDatabase context, IUnitOfWork uow) :
            base(context, uow)
        { 
        }

        public IEnumerable<Project> findProjectWithDeadlineBefore(DateTime deadline)
        {
            return _table.Where(p => p.Deadline == deadline).ToList();
        }

        public override Project FindById(Guid id)
        {
            var proj = _table.Where(p => p.Id == id)
                .Include(p => p.ProjectUsersReq)
                    .ThenInclude(pur => pur.Role)
                .Include(p => p.ProjectUsersReq)
                    .ThenInclude(pur => pur.Sender)
                .Include(p => p.ProjectUsersReq)
                    .ThenInclude(pur => pur.UserAssigned)
                .FirstOrDefault();

            return proj;
                
        }
    }
}
