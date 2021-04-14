using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class CommentDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var comment = modelBuilder.Entity<Comment>();

            comment
                 .HasKey(c => c.Id);

            comment
                .Property(c => c.Created)
                .IsRequired();

            comment
                .Property(c => c.Created)
                .IsRequired()
                .HasMaxLength(350);
        }
    }
}
