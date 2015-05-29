using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Group
    {
        public string Name
        {
            get;
            set;
        }

        public int Id { get; set; }

        public Group(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }

    }
}