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





        public ICollection<ProjectUserReq> RequestsSent { get; set; }

        public ICollection<ProjectUserReq> RequestsReceived { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
