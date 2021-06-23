using BugTracker.contracts.requests.filterAndOrdering;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.users
{
    public static class UsersFilterExtensions
    {
        public static IQueryable<User> ApplyFilterOptions(this IQueryable<User> query, Filter filter)
        {
            if (filter.FilterProperty.ToLower().Equals("all"))
            {
                return query.Where(u => u.UserName.Contains(filter.Value) || u.Email.Contains(filter.Value));
            }

            return query;
        }
    }
}
