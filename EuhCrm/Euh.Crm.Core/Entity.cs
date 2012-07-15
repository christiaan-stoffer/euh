using System;
using System.Collections.Generic;

namespace Euh.Crm.Core
{
    public class Entity
    {
        public Entity()
        {
            Fields = new List<Field>();
        }

        public List<Field> Fields { get; set; }
    }
}