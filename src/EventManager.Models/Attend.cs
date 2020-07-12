using EventManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Models
{
    public class Attend : IModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public Guid EventId { get; set; }
         
        public Event Event { get; set; }
    }
}
