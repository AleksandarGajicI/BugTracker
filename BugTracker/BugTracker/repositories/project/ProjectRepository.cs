using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories
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
    }
}
