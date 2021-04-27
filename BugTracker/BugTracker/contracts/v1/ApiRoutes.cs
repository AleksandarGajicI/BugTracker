using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts
{
    public static class ApiRoutes
    {
        public const string Version = "V1";

        public const string Root = "api";

        public const string Base = Root + "/" + Version;

        public static class Users
        {
            public const string GetAll = Base + "/users";
            public const string GetById = Base + "/users/{id}";
            public const string Register = Base + "/register";
            public const string Update = Base + "/users";
            public const string Delete = Base + "/users";
        }

        public static class Roles
        { 
            public const string GetAll = Base + "/roles";
            public const string GetById = Base + "/roles/id/";
        }

        public static class Projects
        {
            public const string GetAll = Base + "/projects";
            public const string GetById = Base + "/projects/id/";
            public const string Update = Base + "/projects";
            public const string Delete = Base + "/projects";
        }
    }
}
