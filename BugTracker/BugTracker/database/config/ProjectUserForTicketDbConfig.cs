using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class ProjectUserForTicketDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var projectUserForTicket = modelBuilder.Entity<ProjectUserForTicket>();

            projectUserForTicket
                .HasKey(a => new { a.ProjectUserId, a.TicketId });

            projectUserForTicket
                .Property(a => a.Assigned)
                .IsRequired();

            projectUserForTicket
                .Property(a => a.Comment)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}
