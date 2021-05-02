using BugTracker.helpers;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class User : EntityBase
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public  DateTime Joined { get; set; }

        public User()
        {
            RequestsSent = new List<ProjectUserReq>();
            RequestsReceived = new List<ProjectUserReq>();
        }

        public User(string email, string userName, string firstName, string lastName)
            : this()
        {
            Id = Guid.NewGuid();
            Email = email;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Joined = DateTime.Now;
        }



        public ICollection<ProjectUserReq> RequestsSent { get; set; }

        public ICollection<ProjectUserReq> RequestsReceived { get; set; }

        public override string ToString()
        {
            return $"User: " +
                    $"Id: {Id}," +
                    $" UserName: {UserName}," +
                    $" Email: {Email}," +
                    $" FirstName: {FirstName}," +
                    $" LastName: {LastName}," +
                    $" Joined: {Joined}";
        }

        public override void Validate()
        {
            var u = new User();

            if (Id == null)
            { 
                AddBrokenRule(BusinessRule.Make<User, Guid>(u => u.Id,
                                                              MagicStrings.Users.Error.Id));
            }

            if (string.IsNullOrEmpty(Email) || Email == " ")
            {
                AddBrokenRule(BusinessRule.Make<User, string>(u => u.Email, MagicStrings.Users.Error.Email));
            }

            if (string.IsNullOrEmpty(UserName) || UserName == " ")
            {
                AddBrokenRule(BusinessRule.Make<User, string>(u => u.UserName, 
                                                              MagicStrings.Users.Error.UserName));
            }

            if (string.IsNullOrEmpty(FirstName) || FirstName == " ")
            {
                AddBrokenRule(BusinessRule.Make<User, string>(u => u.FirstName,
                                                              MagicStrings.Users.Error.FirstName));
            }

            if (string.IsNullOrEmpty(LastName) || LastName == " ")
            {
                AddBrokenRule(BusinessRule.Make<User, string>(u => u.LastName,
                                                              MagicStrings.Users.Error.LastName));
            }

            if (Joined == null)
            { 
                AddBrokenRule(BusinessRule.Make<User, DateTime>(u => u.Joined,
                                                              MagicStrings.Users.Error.Joined));
            }
            else if (DateTime.Compare(Joined, DateTime.Now) > 0)
            {
                AddBrokenRule(BusinessRule.Make<User, DateTime>(u => u.Joined,
                                                              MagicStrings.Users.Error.JoinedInFuture));
            }
        }
    }
}
