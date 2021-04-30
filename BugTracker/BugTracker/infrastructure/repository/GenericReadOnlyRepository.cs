using BugTracker.database;
using BugTracker.infrastructure.domain;
using BugTracker.repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.repository
{
    public class GenericReadOnlyRepository<T> : IReadOnlyRepository<T>
        where T : EntityBase
    {
        protected readonly DbSet<T> _table;
        protected readonly BugTrackerDatabase _context;

        public GenericReadOnlyRepository(BugTrackerDatabase context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _table.ToList();
        }

        public virtual T FindById(Guid id)
        {
            return _table.Find(id);
        }

        public IQueryable<T> GetBasicQuery()
        {
            return _table.AsQueryable();
        }
    }
}
