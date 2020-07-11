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

        public DbSet<UserModel> Users { get; set; }

        public DbSet<EventModel> Events { get; set; }

        public DbSet<RegistrationModel> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<EventModel>().ToTable("Event");
            modelBuilder.Entity<RegistrationModel>().ToTable("Registration");
        }
    }
}
