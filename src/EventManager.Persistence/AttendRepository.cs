using EventManager.Core.Interfaces;
using EventManager.Database;
using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Persistence
{
    public class AttendRepository : Repository<Attend, Guid>, IAttendRepository
    {
        public AttendRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
