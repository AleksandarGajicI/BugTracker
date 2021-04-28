﻿using BugTracker.infrastructure.contracts.filterAndSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class FindPageRequest<TFilterOptions, TSortingOptions>
        where TFilterOptions : struct, IConvertible
        where TSortingOptions : struct, IConvertible
    {
        public int PageSize { get; set; }
        public int PageNum { get; set; }

        public FindPageRequest(int pageSize = 3, int pageNum = 0)
        {
            Filters = new List<FilterOption<TFilterOptions>>();

            if (pageSize <= 0)
            {
                pageSize = 3;
            }
            else
            {
                PageSize = pageSize;
            }
            if (pageNum < 0)
            {
                pageNum = 0;
            }
            else
            {
                PageNum = pageNum;
            }
        }

        public IEnumerable<FilterOption<TFilterOptions>> Filters { get; set; }

        public TSortingOptions SortingOption { get; set; }
    }
}
