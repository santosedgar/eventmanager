using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Database
{
    public class EventManagerContext : DbContext
    {
        public EventManagerContext(DbContextOptions<EventManagerContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Attend> Attend { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userBuilder = modelBuilder.Entity<User>().ToTable("User");
            var eventBuilder = modelBuilder.Entity<Event>().ToTable("Event");
            var attendBuilder = modelBuilder.Entity<Attend>().ToTable("Attend");

             // USER
             userBuilder.HasKey(u => u.ID);

            userBuilder
                .Property(u => u.ID)
                .ValueGeneratedOnAdd();

            userBuilder
                .Property(u => u.Password)
                .IsRequired();

            //Event
            eventBuilder.HasKey(e => e.ID);

            eventBuilder
                .Property(e => e.ID)
                .ValueGeneratedOnAdd();

            eventBuilder
                .HasMany(e => e.Attendees)
                .WithOne(a => a.Event);

            //Attend
            attendBuilder.HasKey(a => a.ID);

            attendBuilder
                .Property(a => a.ID)
                .ValueGeneratedOnAdd();

            attendBuilder
                .HasOne(a => a.Event)
                .WithMany(e => e.Attendees)
                .HasForeignKey(a => a.EventId);


        }
    }
}
