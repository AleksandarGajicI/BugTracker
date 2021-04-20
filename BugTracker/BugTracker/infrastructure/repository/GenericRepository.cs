using BugTracker.database;
using BugTracker.infrastructure.domain;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.repositories.generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.repository
{
    public class GenericRepository<T> : GenericReadOnlyRepository<T>, IUnitOfWorkRepository, IPersistanceRepository<T>
        where T : EntityBase
    {
        private readonly IUnitOfWork _uow;

        public GenericRepository(BugTrackerDatabase context, IUnitOfWork uow)
            : base(context)
        {
            _uow = uow;

        }


        public void PersistCreationOf(EntityBase entity)
        {
            _context.Add((T)entity);
        }

        public void PersistDeletionOf(EntityBase entity)
        {
            _context.Remove((T)entity);
        }

        public void PersistUpdateOf(EntityBase entity)
        {
            _context.Update((T)entity);
        }

        public void save(T entity)
        {
            _uow.RegisterCreated(entity, this);
        }

        public void update(T entity)
        {
            _uow.RegisterUpdated(entity, this);
        }

        public void delete(Guid id)
        {
            _uow.RegisterDeleted(_table.Find(id), this);
        }
    }
}
