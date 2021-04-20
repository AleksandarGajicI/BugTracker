using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories
{
    public interface IReadOnlyRepository<T> where T : EntityBase
    {
        public T getById(Guid id);
        public IEnumerable<T> findAll();
        public IEnumerable<T> findWithPaging(IQueryable<T> query, int pageNum, int pageSize);
    }
}
