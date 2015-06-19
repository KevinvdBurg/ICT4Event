using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Event
    {
        public int MaxPerson
        {
            get;
            set;
        }

        public Location Location
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int EventID { get; set; }

        public string BeginTime { get; set; }
        public string EndTime { get; set; }

        public Event(Location Location, int MaxPerson, string Name, int EventID, string BeginTime, string EndTime)
        {
            this.Location = Location;
            this.MaxPerson = MaxPerson;
            this.Name = Name;
            this.EventID = EventID;
            this.BeginTime = BeginTime;
            this.EndTime = EndTime;
        }

    }
}