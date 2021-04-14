using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class UserDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user
                .HasKey(u => u.Id);

            user.HasIndex(u => u.Email)
                .IsUnique();

            user.HasIndex(u => u.UserName)
                .IsUnique();

            user
                 .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            user
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            user
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            user
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
