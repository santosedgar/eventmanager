using EventManager.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Core.Interfaces
{
    public interface IEventRepository : IRepository<Event, Guid>
    {
    }
}
