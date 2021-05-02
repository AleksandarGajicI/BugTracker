using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers
{
    public class MagicStrings
    {
        public class Project
        {
            public class Error
            {
                public const string Id = "Project must have an unique identifier!";
                public const string Name = "Project must have a name that is not null or empty character!";
                public const string Deadline = "Project must have a deadline set!";
                public const string UsersOnProject = "Project must have a Project Manager!";
            }
        }

        public class Roles
        {
            public const string ProjectManager = "PROJECT_MANAGER";
        }

        public class Users
        {
            public class Error
            {
                public const string Id = "User must have an unique identifier!";
                public const string Email = "Invalid Email!";
                public const string UserName = "Invalid UserName!";
                public const string FirstName = "Invalid FirstName!";
                public const string LastName = "Invalid LastName!";
                public const string JoinedInFuture = "User can't join in the future!";
                public const string Joined = "User must have a joined property defined!";
                public const string Signup = "Error signing up!";
                public const string Login = "Error loging in!";
                public const string AlreadyExists = "User already exists!";
                public const string NotFound = "User not found!";
            }
        }
    }
}
