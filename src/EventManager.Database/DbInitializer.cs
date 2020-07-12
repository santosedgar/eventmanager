using EventManager.Database;
using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager
{
    public class DbInitializer
    {
        public static void Initialize(EventManagerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }
            var users = new User[]
            {
                new User
                {
                    Username = "admin",
                    Password = "admin",
                    RoleId = Role.EventCreator
                }
            };


            context.Users.AddRange(users);

            var events = new Event[]
            {
                new Event
                {
                    Name = "Event 1",
                    Description= "description 1",
                    Location= "location 1",
                    StartTime =  DateTime.Now.AddDays(-1),
                    EndTime = DateTime.Now.AddDays(1),
                    User = users.First()
                }
            };

            
            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}
