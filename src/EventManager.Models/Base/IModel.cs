using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Models.Base
{
    public abstract class IModel
    {
        public Guid ID { get; protected set; }
    }
}
