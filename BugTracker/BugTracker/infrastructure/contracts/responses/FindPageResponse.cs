using BugTracker.dto;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class FindPageResponse<T> : BaseResponse
        where T : BaseDTO
    {
        public ICollection<T> EntitiesDTO { get; set; }
        public int PageNum { get; set; }
        public int MaxPage { get; set; }
        public int PageSize { get; set; }

        public FindPageResponse()
            : base()
        {
        }
    }
}
