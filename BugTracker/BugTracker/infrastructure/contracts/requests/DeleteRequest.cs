﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class DeleteRequest : BaseRequest
    {
        public Guid Id { get; set; }
    }
}