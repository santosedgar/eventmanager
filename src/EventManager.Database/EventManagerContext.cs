using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Database
{
    public class EventManagerContext: DbContext
    {
        public EventManagerContext(DbContextOptions<EventManagerContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attend> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            var userBuilder = modelBuilder.Entity<User>();
            var eventBuilder = modelBuilder.Entity<Event>();
            var attendBuilder = modelBuilder.Entity<Attend>();

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Attend>().ToTable("Attend");


        }
    }
}
