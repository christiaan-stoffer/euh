using System;
using System.Collections.Generic;

using System.IO;
using System.Reflection;

namespace Euh.Crm.Core
{
    public class Entity
    {
        public Entity()
        {
            Fields = new List<Field>();
        }

        public List<Field> Fields { get; set; }
        public string Name { get; set; }
        public void Shizzle()
        {
            using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Euh.Crm.Core.template.txt"))
            {
                using (var reader = new StreamReader(s))
                {
                    var contents = string.Format(reader.ReadToEnd(), "MyShizzle");
                }
            }
        }
    }
}