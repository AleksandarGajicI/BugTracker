using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class ProjectDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var project = modelBuilder.Entity<Project>();

            project
               .HasKey(p => p.Id);

            project
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            project
                .Property(p => p.Description)
                .HasMaxLength(350);

            project
                .Property(p => p.Deadline)
                .IsRequired();

            project
                .Property(p => p.Closed)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
