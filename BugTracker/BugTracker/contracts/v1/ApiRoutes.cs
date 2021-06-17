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
            public const string Login = Base + "/users/login";
        }

        public static class Roles
        { 
            public const string GetAll = Base + "/roles";
            public const string GetById = Base + "/roles/id/";
        }

        public static class Projects
        {
            public const string GetAll = Base + "/projects";
            public const string GetById = Base + "/projects/{id}";
            public const string Update = Base + "/projects/{id}";
            public const string Delete = Base + "/projects/{id}";
            public const string Create = Base + "/projects";
            public const string GetPage = Base + "/projects/page";
        }

        public static class ProjectUserReq
        {
            public const string GetAll = Base + "/projectUserReq";
            public const string GetById = Base + "/projectUserReq/id";
            public const string Update = Base + "/projectUserReq";
            public const string Delete = Base + "/projectUserReq";
            public const string Create = Base + "/projectUserReq";
            public const string Reply = Base + "/projectUserReq/Reply";

        }

        public static class TicketStatus
        { 
            public const string GetAll = Base + "/ticketStatus";
        }

        public static class Tickets
        {
            public const string GetAll = Base + "/tickets";
            public const string GetById = Base + "/tickets/{id}";
            public const string Update = Base + "/tickets/{id}";
            public const string Delete = Base + "/tickets/{id}";
            public const string Create = Base + "/tickets";

        }
    }
}
