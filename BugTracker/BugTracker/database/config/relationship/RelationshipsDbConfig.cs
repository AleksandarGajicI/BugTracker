using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config.relationship
{
    public class RelationshipsDbConfig
    {
        public static void ConfigureRealtionships(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            var project = modelBuilder.Entity<Project>();
            var projectUserReq = modelBuilder.Entity<ProjectUserReq>();
            var ticket = modelBuilder.Entity<Ticket>();

            user.HasMany(u => u.RequestsSent)
               .WithOne(r => r.Sender);

            user.HasMany(u => u.RequestsReceived)
                .WithOne(r => r.UserAssigned)
                .HasForeignKey(r => r.UserAssignedId);

            project.HasMany(p => p.Tickets)
                .WithOne(t => t.Project);

            projectUserReq.HasMany(p => p.AssignedForTicket)
                .WithOne()
                .HasForeignKey(p => p.ProjectUserId);

            ticket.HasMany(t => t.AssignedUsers)
                .WithOne()
                .HasForeignKey(p => p.TicketId);


        }
    }
}
