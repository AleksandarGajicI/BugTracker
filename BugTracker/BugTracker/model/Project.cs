using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Project : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Closed { get; set; }






        public ICollection<ProjectUserReq> ProjectUsersReq { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            var owner = ProjectUsersReq?.Where(x => x.Role?.RoleName == "PROJECT_MANAGER")
                                        .OrderBy(x => x.RequestSent)
                                        .Select(x => x.UserAssigned)
                                        .FirstOrDefault();

            return $"Project:" +
                    $" Id: {Id}," +
                    $" Name: {Name}," +
                    $" Description: {Description}," +
                    $" Deadline: {Deadline}," +
                    $" Closed: {Closed}," +
                    $" OwnerId: {owner.Id}," +
                    $" OwnerUserName: {owner.UserName}";
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
