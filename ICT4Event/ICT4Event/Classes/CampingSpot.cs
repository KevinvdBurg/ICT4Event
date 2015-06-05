using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class CampingSpot
    {
        public CampingSpot(int ID, int locationID, string number, int maxPeople)
        {
            this.ID = ID;
            this.LocationID = locationID;
            this.Number = number;
            this.MaxPeople = maxPeople;
        }

        public CampingSpot(int locationID, string number, int maxPeople)
        {
            this.LocationID = locationID;
            this.Number = number;
            this.MaxPeople = maxPeople;
        }
        public int ID { get; set; }

        public int LocationID { get; set; }

        public string Number { get; set; }

        public int MaxPeople { get; set; }
    }
}