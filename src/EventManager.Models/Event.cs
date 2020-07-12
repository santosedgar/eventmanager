using EventManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Models
{
    public class Event : IModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
