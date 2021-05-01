using BugTracker.helpers;
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

        public Project()
        {
            ProjectUsersReq = new List<ProjectUserReq>();
            Tickets = new List<Ticket>();
        }

        public Project(string name, 
                        string description, 
                        DateTime deadline, 
                        bool closed = false)
            : this()
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Deadline = deadline;
            Closed = closed;
        }



        public ICollection<ProjectUserReq> ProjectUsersReq { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            var owner = ProjectUsersReq?.Where(x => x.Role?.RoleName == MagicStrings.Roles.ProjectManager)
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

        public override void Validate()
        {

            var proj = new Project();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                AddBrokenRule(BusinessRule.Make<Project, string>
                                            (proj => proj.Name, MagicStrings.Project.Error.Name));

            }

            if (Deadline == null)
            {
                AddBrokenRule(BusinessRule.Make<Project, DateTime>(proj => proj.Deadline, 
                                                                   MagicStrings.Project.Error.Deadline));
            }

            if (Id == null)
            {
                AddBrokenRule(BusinessRule.Make<Project, Guid>(proj => proj.Id,
                                                               MagicStrings.Project.Error.Id));
            }

            if (ProjectUsersReq.Count > 0 && ProjectUsersReq
                                            .Where(pur => pur.Role.RoleName == MagicStrings.Roles.ProjectManager) == null)
            {
                AddBrokenRule(BusinessRule.Make<Project, ICollection<ProjectUserReq>>(proj => proj.ProjectUsersReq,
                                                                                      MagicStrings.Project.Error.UsersOnProject));
            }

        }

        public void AddTicket(Ticket ticket)
        {
            if (ticket.Project is null)
            {
                ticket.Project = this;
            }

            if (!Tickets.Contains(ticket))
            {
                Tickets.Add(ticket);
            }
        }

        public void AddUserToProject(ProjectUserReq user)
        {
            if (user.Project is null)
            {
                user.Project = this;
            }

            if (!ProjectUsersReq.Contains(user))
            {
                ProjectUsersReq.Add(user);
            }
        }
    }
}
