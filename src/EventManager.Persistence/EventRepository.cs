using EventManager.Database;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Persistence
{
    public class EventRepository
    {
        private readonly EventManagerContext _context;

        public EventRepository(EventManagerContext context)
        {
            this._context = context;
        }

        public virtual async Task<EntityEntry<EventModel>> AddAsync(EventModel entity)
        {
            return await this._context
                .Set<EventModel>()
                .AddAsync(entity);
        }

        public virtual async Task<IEnumerable<EventModel>> ListAsync()
        {
            return await this._context
                .Set<EventModel>()
                .ToListAsync();
        }
    }
}
