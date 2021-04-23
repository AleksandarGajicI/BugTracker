﻿using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.user
{
    public class CreateUserRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
