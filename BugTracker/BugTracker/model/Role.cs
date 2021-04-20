using BugTracker.infrastructure.domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.model
{
    public class Role : EntityBase
    {   
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
