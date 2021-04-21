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

        public Role(string roleName, string description)
        {
            RoleName = roleName;
            Description = description;
        }

        public override string ToString()
        {
            return $"Role:" +
                    $" Id: {Id}," +
                    $" RoleName: {RoleName}," +
                    $" Description: {Description}";
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
