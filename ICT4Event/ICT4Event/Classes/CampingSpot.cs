using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class CampingSpot
    {
        //public int Location
        //{
        //    get;
        //    set;
        //}

        public CategorySpots Category { get; set; }
        public int LocationID { get; set; }

        public int SpotID { get; set; }

        public CampingSpot(CategorySpots category, int locationid, int spotID)
        {
            //this.Location = Location;
            this.Category = category;
            this.LocationID = locationid;
            this.SpotID = spotID;
        }
    }
}