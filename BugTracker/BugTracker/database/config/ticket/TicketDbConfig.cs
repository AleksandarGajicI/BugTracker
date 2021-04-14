using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class TicketDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var ticket = modelBuilder.Entity<Ticket>();

            ticket
                .HasKey(t => t.Id);

            ticket
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            ticket
                .Property(t => t.Created)
                .IsRequired();

            ticket
                .Property(t => t.Deadline)
                .IsRequired();

            ticket
                .Property(t => t.Description)
                .HasMaxLength(500);

            ticket
                .Property(t => t.Type)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(200);
        }
    }
}
