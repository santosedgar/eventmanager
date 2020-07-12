using EventManager.Core.Interfaces;
using EventManager.Database;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Persistence
{
    public class EventRepository: Repository<Event, Guid>, IEventRepository
    {
        public EventRepository(EventManagerContext context) : base(context)
        {
        }

        public Task<Event> GetAttendeesAsync(Guid Id)
        {
            return this.Context.Events
                .Include(en => en.Attendees)
                .FirstAsync(ev => ev.ID == Id);
                
        }
    }
}
