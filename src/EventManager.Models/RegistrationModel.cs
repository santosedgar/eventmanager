using EventManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Models
{
    public class RegistrationModel : IModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public UserModel CreatedBy { get; set; }
         
        public EventModel EventModel { get; set; }
    }
}
