using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Request
{
    public class EventRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
