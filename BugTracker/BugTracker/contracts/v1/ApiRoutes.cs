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
            public const string GetAll = Base + "/users/all";
            public const string GetById = Base + "/users/{id}";
            public const string Register = Base + "/register";
            public const string Update = Base + "/users";
            public const string Delete = Base + "/users";
            public const string Login = Base + "/users/login";
            public const string Page = Base + "/users";
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
            public const string GetAll = Base + "/requests";
            public const string GetAllSent = Base + "/requests/sent";
            public const string GetById = Base + "/requests/id";
            public const string Update = Base + "/requests";
            public const string Delete = Base + "/requests/{id}";
            public const string Create = Base + "/requests";
            public const string Reply = Base + "/requests/reply";

        }

        public static class TicketStatus
        { 
            public const string GetAll = Base + "/ticketStatus";
        }

        public static class Tickets
        {
            public const string GetAll = Base + "/tickets";
            public const string Page = Base + "/tickets/page";
            public const string GetAllForProject = Base + "/tickets/projects/{id}";
            public const string GetById = Base + "/tickets/{id}";
            public const string Update = Base + "/tickets/{id}";
            public const string Delete = Base + "/tickets/{id}";
            public const string Create = Base + "/tickets";

        }

        public static class TicketHistories
        {
            public const string GetByTicketId = Base + "/ticketHistories/{id}";

        }

        public static class Comments
        {
            public const string GetAllForTicket = Base + "/comments/{id}";
            public const string GetPageForTicket = Base + "/comments/page/{id}";
            public const string Delete = Base + "/comments/{id}";
            public const string Create = Base + "/comments";

        }
    }
}
