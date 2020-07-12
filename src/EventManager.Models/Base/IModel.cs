using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Models.Base
{
    public abstract class IModel
    {
        public Guid ID { get; protected set; }
    }
}
