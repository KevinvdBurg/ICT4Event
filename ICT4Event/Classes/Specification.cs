using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    public class Specification
    {
        public Specification(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }

        public Specification(string name)
        {
            this.Name = name;
        }
        public int ID { get; set; }

        public string Name { get; set; }
    }
}