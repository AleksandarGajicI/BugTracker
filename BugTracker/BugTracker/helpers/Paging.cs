using BugTracker.infrastructure.domain;
using System;
using System.Linq;

namespace BugTracker.helpers
{
    public static class Paging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNum, int pageSize)
            where T: EntityBase
        {
            if (pageSize <= 0)
            {
                throw new Exception("Page size must be a number above zero!");
            }

            if (pageNum > 1)
            {
                query.Skip((pageNum - 1) * pageSize);
            }

            return query.Take(pageSize);

        }
    }
}
