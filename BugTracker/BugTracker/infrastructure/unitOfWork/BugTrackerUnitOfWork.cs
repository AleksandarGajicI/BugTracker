﻿using BugTracker.database;
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
                    Console.WriteLine("saving");
                    Console.WriteLine("Db context: " + _bugTrackerDbContext);
                    createdEntities[created].PersistCreationOf(created);
                }

                foreach (var updated in updatedEntities.Keys)
                {
                    Console.WriteLine("updating");
                    updatedEntities[updated].PersistUpdateOf(updated);
                }

                foreach (var deleted in deletedEntities.Keys)
                {
                    Console.WriteLine("deleting");
                    deletedEntities[deleted].PersistDeletionOf(deleted);
                }

                Console.WriteLine("calling saving changes");

                _bugTrackerDbContext.SaveChanges();
                transaction.Commit();

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
