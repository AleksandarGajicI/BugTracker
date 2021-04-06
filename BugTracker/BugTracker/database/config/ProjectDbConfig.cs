using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class ProjectDbConfig
    {
        public static void ConfigureProjectTable(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .HasMaxLength(350);

            modelBuilder.Entity<Project>()
                .Property(p => p.Deadline)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(p => p.Closed)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
