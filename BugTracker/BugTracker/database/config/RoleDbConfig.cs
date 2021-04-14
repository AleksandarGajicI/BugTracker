using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class RoleDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var role = modelBuilder.Entity<Role>();

            role
                .HasKey(r => r.Id);

            role.HasIndex(r => r.RoleName)
                .IsUnique();

            role
                .Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            role
                .Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(350);
        }
    }
}
