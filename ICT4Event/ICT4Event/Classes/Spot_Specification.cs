using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    public class Spot_Specification
    {
        public Spot_Specification(int ID, Specification specification, CampingSpot campingSpot, double value)
        {
            this.ID = ID;
            this.Specification = specification;
            this.CampingSpot = campingSpot;
            this.Value = value;
        }

        public Spot_Specification(Specification specification, CampingSpot campingSpot, double value)
        {
            this.Specification = specification;
            this.CampingSpot = campingSpot;
            this.Value = value;
        }
        public int ID { get; set; }

        public Specification Specification { get; set; }

        public CampingSpot CampingSpot { get; set; }

        public double Value { get; set; }
    }
}