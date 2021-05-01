using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.uri
{
    public interface IUriService
    {
        public Uri GetAllUri(PagedQuery query);
    }
}
