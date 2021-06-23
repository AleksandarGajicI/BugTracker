using BugTracker.database;
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
                .Include(pur => pur.Project)
                .FirstOrDefault();
        }

        public ProjectUserReq FindProjectUserFor(Guid userId, Guid projectId)
        {
            return _table.Where(uop => uop.UserAssignedId == userId &&
                                uop.ProjectId == projectId)
                         .FirstOrDefault();
        }

        public ICollection<ProjectUserReq> FindReceivedReqFor(Guid userId)
        {
            return _table.Where(pur => pur.UserAssigned.Id.Equals(userId) && 
                                !pur.UserAssigned.Id.Equals(pur.Sender.Id) &&
                                !pur.Accepted)
                        .Include(pur => pur.Role)
                        .Include(pur => pur.Project)
                        .Include(pur => pur.Sender)
                .ToList();
        }

        public ICollection<ProjectUserReq> FindSentReqFor(Guid userId)
        {
            return _table.Where(pur => pur.Sender.Id.Equals(userId) &&
                                !pur.UserAssigned.Id.Equals(pur.Sender.Id) &&
                                !pur.Accepted)
                        .Include(pur => pur.Role)
                        .Include(pur => pur.Project)
                        .Include(pur => pur.Sender)
                .ToList();
        }
    }
}
