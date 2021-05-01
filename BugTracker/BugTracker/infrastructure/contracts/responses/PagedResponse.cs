using BugTracker.dto;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class PagedResponse<T> : ResponseBase
        where T : BaseDTO
    {
        public IEnumerable<T> EntitiesDTO { get; set; }
        public int PageNum { get; set; }
        public int MaxPage { get; set; }
        public int PageSize { get; set; }
        public string NextPage { get; set; }
        public string PrevPage { get; set; }

        public PagedResponse()
            : base()
        {
        }
    }
}
