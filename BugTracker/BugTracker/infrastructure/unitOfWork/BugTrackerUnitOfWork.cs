using BugTracker.database;
using BugTracker.infrastructure.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.unitOfWork
{
    public class BugTrackerUnitOfWork : IUnitOfWork
    {
        IDictionary<EntityBase, IUnitOfWorkRepository> createdEntities = 
            new Dictionary<EntityBase, IUnitOfWorkRepository>();
        IDictionary<EntityBase, IUnitOfWorkRepository> updatedEntities = 
            new Dictionary<EntityBase, IUnitOfWorkRepository>();
        IDictionary<EntityBase, IUnitOfWorkRepository> deletedEntities = 
            new Dictionary<EntityBase, IUnitOfWorkRepository>();

        private readonly BugTrackerDatabase _bugTrackerDbContext;

        public BugTrackerUnitOfWork(BugTrackerDatabase context)
        {
            _bugTrackerDbContext = context;
        }

        public void Commit()
        {
            using (var transaction = _bugTrackerDbContext.Database.BeginTransaction())
            {
                foreach (var created in createdEntities.Keys)
                {
                    createdEntities[created].PersistCreationOf(created);
                }

                foreach (var updated in updatedEntities.Keys)
                {
                    updatedEntities[updated].PersistCreationOf(updated);
                }

                foreach (var deleted in deletedEntities.Keys)
                {
                    deletedEntities[deleted].PersistCreationOf(deleted);
                }

                _bugTrackerDbContext.SaveChanges();

            }
        }

        public void RegisterCreated(EntityBase entity, IUnitOfWorkRepository repo)
        {
            if (!createdEntities.ContainsKey(entity))
            {
                createdEntities.Add(entity, repo);
            }
        }

        public void RegisterDeleted(EntityBase entity, IUnitOfWorkRepository repo)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity, repo);
            }
        }

        public void RegisterUpdated(EntityBase entity, IUnitOfWorkRepository repo)
        {
            if (!updatedEntities.ContainsKey(entity))
            {
                updatedEntities.Add(entity, repo);
            }
        }
    }
}
