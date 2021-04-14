using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class ProjectUserReqDbConfig : IConfigDB
    {
        

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var projectUserReq = modelBuilder.Entity<ProjectUserReq>();

            projectUserReq
                 .HasKey(t => t.Id);

            projectUserReq
                .Property(u => u.RequestSent)
                .IsRequired();

            projectUserReq
                 .Property(u => u.Accepted)
                .IsRequired()
                .HasDefaultValue(false);

            projectUserReq
                 .Property(u => u.Message)
                .HasMaxLength(250);

            projectUserReq
                .HasIndex(t => new { t.UserAssignedId, t.ProjectId }).IsUnique();
        }
    }
}
