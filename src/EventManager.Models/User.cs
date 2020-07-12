using EventManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Models
{
    public class User : IModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Role RoleId { get; set; }
    }
}
