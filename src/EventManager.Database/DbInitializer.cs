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

            context.SaveChanges();
        }
    }
}
