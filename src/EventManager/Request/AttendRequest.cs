using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Request
{
    public class AttendRequest
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public Guid EventId { get; set; }
    }
}
